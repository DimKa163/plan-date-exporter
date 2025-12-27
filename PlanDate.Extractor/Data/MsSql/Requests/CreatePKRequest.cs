using System.Reflection;
using Dapper;
using Microsoft.Data.SqlClient;

namespace PlanDate.Extractor.Data.MsSql.Requests;

public class CreatePKRequest : IEntityRequest
{
    public Task ExecuteAsync(SqlConnection connection, Type type, CancellationToken token = default)
    {
        PropertyInfo[] props = type.GetProperties().Where(p => p.GetCustomAttribute<Identity>() is not null).ToArray();
        if (props.Length == 0)
            throw new ArgumentException($"The type {type.Name} has no identity property");
        if (props.Length > 1)
            throw new InvalidOperationException($"There are multiple identity properties with the name {props[0].Name}");

        string columnName = props[0].Name;
        MsSqlColumn? attrColumn = props[0].GetCustomAttribute<MsSqlColumn>();
        if (attrColumn is not null)
            columnName = attrColumn.ColumnName;
        string tableName = type.Name;
        MsSqlTable? attr = type.GetCustomAttribute<MsSqlTable>();
        if (attr is not null)
            tableName = attr.TableName;
        string query = $"ALTER TABLE [dbo].[{tableName}] ADD CONSTRAINT [PK_{tableName}] PRIMARY KEY ([{columnName}]);";
        return connection.ExecuteAsync(query);
    }
}