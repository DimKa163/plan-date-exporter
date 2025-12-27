using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Dapper;
using Microsoft.Data.SqlClient;

namespace PlanDate.Extractor.Data.MsSql.Requests;

public class TableRequest : IEntityRequest
{
    public Task ExecuteAsync(SqlConnection connection, Type type, CancellationToken token = default)
    {
        string tableName = type.Name;
        MsSqlTable? attr = type.GetCustomAttribute<MsSqlTable>();
        if (attr is not null)
            tableName = attr.TableName;
        PropertyInfo[] props = type
            .GetProperties()
            .OrderBy(x => x.GetCustomAttribute<Identity>())
            .ToArray();
        List<string> propExprs = new(props.Length);
        foreach (PropertyInfo prop in props)
        {
            string propName = prop.Name;
            MsSqlColumn? attrColumn = prop.GetCustomAttribute<MsSqlColumn>();
            if (attrColumn is not null)
                propName = attrColumn.ColumnName;
            MaxLengthAttribute? attrLen = prop.GetCustomAttribute<MaxLengthAttribute>();
            switch (prop.PropertyType)
            {
                case var _ when prop.PropertyType == typeof(Guid):
                    propExprs.Add($"[{propName}] UNIQUEIDENTIFIER NOT NULL");
                    break;
                case var _ when prop.PropertyType == typeof(Guid?):
                    propExprs.Add($"[{propName}] UNIQUEIDENTIFIER NULL");
                    break;
                case var _ when prop.PropertyType == typeof(DateTime?):
                    propExprs.Add($"[{propName}] DATETIME2(3) NULL");
                    break;
                case var _ when prop.PropertyType == typeof(TimeSpan?):
                    propExprs.Add($"[{propName}] TIME(7) NULL");
                    break;
                case var _ when prop.PropertyType == typeof(string) && attrLen is not null:
                    propExprs.Add($"[{propName}] NVARCHAR({attrLen.Length}) NOT NULL");
                    break;
                case var _ when prop.PropertyType == typeof(string):
                    propExprs.Add($"[{propName}] NVARCHAR(MAX) NOT NULL");
                    break;
                case var _ when prop.PropertyType == typeof(int):
                    propExprs.Add($"[{propName}] INT NOT NULL");
                    break;
                case var _ when prop.PropertyType == typeof(bool):
                    propExprs.Add($"[{propName}] BIT NOT NULL");
                    break;
                case var _ when prop.PropertyType == typeof(decimal):
                    propExprs.Add($"[{propName}] DECIMAL(18,3) NOT NULL");
                    break;
            }
        }
        string query = $"CREATE TABLE [dbo].[{tableName}] ({string.Join(", ", propExprs)});";
        return connection.ExecuteAsync(query);
    }
}