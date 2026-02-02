using System.Data.Common;
using System.Reflection;
using Dapper;

namespace PlanDate.Extractor.Data.Npgsql.Requests;

public class MultipleImportRequest : IMultipleEntityImportRequest
{
    public async Task ImportAsync(DbConnection connection, IEnumerable<object> values, CancellationToken token = default)
    {
        var enumerable = values.ToList();
        if (!enumerable.Any())
            return;
        Type entityType = enumerable.First().GetType();
        string tableName = entityType.Name;
        NpgsqlTable? table = entityType.GetCustomAttribute<NpgsqlTable>();
        if (table is not null)
            tableName = table.TableName;
        var properties = entityType.GetProperties();
        List<string> columns = new(properties.Length);
        List<string> columnVal = new();
        foreach (PropertyInfo property in properties)
        {
            string columnName = property.Name;
            NpgsqlColumn? col = property.GetCustomAttribute<NpgsqlColumn>();
            if (col != null)
            {
                columnName = col.ColumnName;
            }
            columns.Add($"{columnName}");
            columnVal.Add($"@{property.Name}");
        }

        string query =
            $"INSERT INTO public.{tableName} ({string.Join(", ", columns)}) VALUES ({string.Join(", ", columnVal)})";
        await connection.ExecuteAsync(query, 
            enumerable);
    }
}