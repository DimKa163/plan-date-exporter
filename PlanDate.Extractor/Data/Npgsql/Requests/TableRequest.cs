using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Reflection;
using Dapper;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace PlanDate.Extractor.Data.Npgsql.Requests;

public class TableRequest : IEntityRequest
{
    public Task ExecuteAsync(DbConnection connection, Type type, CancellationToken token = default)
    {
         string tableName = type.Name;
         NpgsqlTable? attr = type.GetCustomAttribute<NpgsqlTable>();
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
            NpgsqlColumn? attrColumn = prop.GetCustomAttribute<NpgsqlColumn>();
            if (attrColumn is not null)
                propName = attrColumn.ColumnName;
            MaxLengthAttribute? attrLen = prop.GetCustomAttribute<MaxLengthAttribute>();
            switch (prop.PropertyType)
            {
                case var _ when prop.PropertyType == typeof(Guid):
                    propExprs.Add($"{propName} uuid not null");
                    break;
                case var _ when prop.PropertyType == typeof(Guid?):
                    propExprs.Add($"{propName} uuid null");
                    break;
                case var _ when prop.PropertyType == typeof(DateTime?):
                    propExprs.Add($"{propName} timestamptz null");
                    break;
                case var _ when prop.PropertyType == typeof(TimeSpan?):
                    propExprs.Add($"{propName} interval  null");
                    break;
                case var _ when prop.PropertyType == typeof(string) && attrLen is not null:
                    propExprs.Add($"{propName} varchar({attrLen.Length}) not null");
                    break;
                case var _ when prop.PropertyType == typeof(string):
                    propExprs.Add($"{propName} text not null");
                    break;
                case var _ when prop.PropertyType == typeof(int):
                    propExprs.Add($"{propName} integer not null");
                    break;
                case var _ when prop.PropertyType == typeof(bool):
                    propExprs.Add($"{propName} boolean not null");
                    break;
                case var _ when prop.PropertyType == typeof(decimal):
                    propExprs.Add($"{propName} numeric(18, 2) not null");
                    break;
            }
        }
        string query = $"CREATE TABLE public.{tableName} ({string.Join(", ", propExprs)});";
        return connection.ExecuteAsync(query);
    }
}