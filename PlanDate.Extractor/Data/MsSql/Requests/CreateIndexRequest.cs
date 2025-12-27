using System.Reflection;
using Dapper;
using Microsoft.Data.SqlClient;

namespace PlanDate.Extractor.Data.MsSql.Requests;

public class CreateIndexRequest : IEntityRequest
{
    public Task ExecuteAsync(SqlConnection connection, Type type, CancellationToken token = default)
    {
        PropertyInfo[] props = type.GetProperties()
            .Where(p => p.GetCustomAttribute<IndexAttribute>() is not null)
            .ToArray();
        if (props.Length == 0)
            return Task.CompletedTask;
        string tableName = type.Name;
        MsSqlTable? table = type.GetCustomAttribute<MsSqlTable>();
        if (table is not null)
            tableName = table.TableName;
        List<string> expressions = new(props.Length);
        foreach (PropertyInfo prop in props)
        {
            IndexAttribute attr = prop.GetCustomAttribute<IndexAttribute>()!;
            string columnName = prop.Name;
            MsSqlColumn? column = prop.GetCustomAttribute<MsSqlColumn>();
            if (column is not null)
                columnName = column.ColumnName;
            string prf = attr.Unique ? "UX" : "IX";
            expressions.Add($"CREATE INDEX [{prf}_{columnName}] ON [dbo].[{tableName}]([{columnName}] {attr.Direction});");
        }
        
        string query = string.Join("\n", expressions);
        return connection.ExecuteAsync(query);
    }
}