using System.Data.Common;
using System.Reflection;
using Dapper;

namespace PlanDate.Extractor.Data.Npgsql.Requests;

public class CreateIndexRequest : IEntityRequest
{
    public Task ExecuteAsync(DbConnection connection, Type type, CancellationToken token = default)
    {
        PropertyInfo[] props = type.GetProperties()
            .Where(p => p.GetCustomAttribute<IndexAttribute>() is not null)
            .ToArray();
        if (props.Length == 0)
            return Task.CompletedTask;
        string tableName = type.Name;
        NpgsqlTable? table = type.GetCustomAttribute<NpgsqlTable>();
        if (table is not null)
            tableName = table.TableName;
        List<string> expressions = new(props.Length);
        foreach (PropertyInfo prop in props)
        {
            IndexAttribute attr = prop.GetCustomAttribute<IndexAttribute>()!;
            string columnName = prop.Name;
            NpgsqlColumn? column = prop.GetCustomAttribute<NpgsqlColumn>();
            if (column is not null)
                columnName = column.ColumnName;
            string prf = attr.Unique ? "UX" : "IX";
            string indexExpr = attr.Unique ? "UNIQUE INDEX" : "INDEX";
            expressions.Add($"CREATE {indexExpr} {prf}_{tableName}_{columnName} ON public.{tableName}(\"{columnName}\" {attr.Direction});");
        }
        
        string query = string.Join("\n", expressions);
        return connection.ExecuteAsync(query);
    }
}