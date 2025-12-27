using System.Reflection;
using Dapper;
using Microsoft.Data.SqlClient;
using PlanDate.Extractor.Entities;

namespace PlanDate.Extractor.Data.MsSql.Requests;

public class ReadRequest<TEntity> : IEntityReadRequest<TEntity> where TEntity : CreatioEntity
{
    public IAsyncEnumerable<TEntity> ReadAsync(SqlConnection connection, CancellationToken token = default)
    {
        Type entityType = typeof(TEntity);
        string tableName = entityType.Name;
        MsSqlTable? attribute = entityType.GetCustomAttribute<MsSqlTable>();
        if (attribute is not null)
            tableName = attribute.TableName;
        PropertyInfo[] properties = entityType.GetProperties();
        List<string> columns = new(properties.Length);
        foreach (PropertyInfo property in properties)
        {
            string columnName = property.Name;
            MsSqlColumn? columnAttribute = property.GetCustomAttribute<MsSqlColumn>();
            if (columnAttribute is not null)
                columnName = columnAttribute.ColumnName;
            columns.Add($"[{columnName}]");
        }
        return connection.QueryUnbufferedAsync<TEntity>($"SELECT {string.Join(", ", columns)} FROM {tableName}");
    }
}