using System.Reflection;
using Dapper;
using Microsoft.Data.SqlClient;

namespace PlanDate.Extractor.Data.MsSql.Requests;

public class CreateReferenceRequest : IEntityRequest
{
    public Task ExecuteAsync(SqlConnection connection, Type type, CancellationToken token = default)
    {
        PropertyInfo[] props = type.GetProperties().Where(p => p.GetCustomAttribute<Reference>() is not null).ToArray();
        if (props.Length == 0)
            return Task.CompletedTask;
        string tableName = type.Name;
        MsSqlTable? table = type.GetCustomAttribute<MsSqlTable>();
        if (table is not null)
            tableName = table.TableName;
        List<string> expressions = new(props.Length);
        foreach (PropertyInfo prop in props)
        {
            Reference attrRef = prop.GetCustomAttribute<Reference>()!;
            Type dest = attrRef.Type;
            string destName = dest.Name;
            MsSqlTable? destTable = prop.GetCustomAttribute<MsSqlTable>();
            if (destTable is not null)
                destName = dest.Name;
            string columnName = prop.Name;
            MsSqlColumn? column = prop.GetCustomAttribute<MsSqlColumn>();
            if (column is not null)
                columnName = column.ColumnName;
            expressions.Add($"ALTER TABLE [dbo].[{tableName}] ADD CONSTRAINT [FK_{tableName}_{columnName}_{destTable}] FOREIGN KEY ([{columnName}])  REFERENCES [dbo].[{destName}]([{attrRef.ColumnName}]);");
        }
        string query = string.Join("\n", expressions);
        return connection.ExecuteAsync(query);
    }
}