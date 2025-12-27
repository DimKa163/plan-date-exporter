using System.Reflection;
using Dapper;
using Microsoft.Data.SqlClient;

namespace PlanDate.Extractor.Data.MsSql.Requests;

public class ImportRequest : IEntityImportRequest
{
    public async Task ImportAsync(SqlConnection connection, object model, CancellationToken token = default)
    {
        Type entityType = model.GetType();
        string tableName = entityType.Name;
        MsSqlTable? table = entityType.GetCustomAttribute<MsSqlTable>();
        if (table is not null)
            tableName = table.TableName;
        var properties = entityType.GetProperties();
        List<string> columns = new(properties.Length);
        List<string> columnVal = new();
        foreach (PropertyInfo property in properties)
        {
            string columnName = property.Name;
            MsSqlColumn? col = property.GetCustomAttribute<MsSqlColumn>();
            if (col != null)
            {
                columnName = col.ColumnName;
            }
            columns.Add($"[{columnName}]");
            columnVal.Add($"@{columnName}");
        }
        
        await connection.ExecuteAsync(
            $"INSERT INTO [dbo].[{tableName}] ({string.Join(", ", columns)}) VALUES ({string.Join(", ", columnVal)})", 
            model);
    }
}