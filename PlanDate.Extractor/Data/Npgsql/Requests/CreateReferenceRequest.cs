using System.Data.Common;
using System.Reflection;
using Dapper;
using PlanDate.Extractor.Data.MsSql;

namespace PlanDate.Extractor.Data.Npgsql.Requests;

public class CreateReferenceRequest : IEntityRequest
{
    public Task ExecuteAsync(DbConnection connection, Type type, CancellationToken token = default)
    {
        PropertyInfo[] props = type.GetProperties().Where(p => p.GetCustomAttribute<Reference>() is not null).ToArray();
        if (props.Length == 0)
            return Task.CompletedTask;
        string tableName = type.Name;
        NpgsqlTable? table = type.GetCustomAttribute<NpgsqlTable>();
        if (table is not null)
            tableName = table.TableName;
        List<string> expressions = new(props.Length);
        foreach (PropertyInfo prop in props)
        {
            Reference attrRef = prop.GetCustomAttribute<Reference>()!;
            Type dest = attrRef.Type;
            string destName = dest.Name;
            PropertyInfo identityProp = dest.GetProperties().First(p => p.GetCustomAttribute<Identity>() is not null);
            string identityName = identityProp.Name;
            NpgsqlColumn? identityColumn = identityProp.GetCustomAttribute<NpgsqlColumn>();
            if (identityColumn is not null)
                identityName = identityColumn.ColumnName;
            NpgsqlTable? destTable = dest.GetCustomAttribute<NpgsqlTable>();
            if (destTable is not null)
                destName = destTable.TableName;
            string columnName = prop.Name;
            NpgsqlColumn? column = prop.GetCustomAttribute<NpgsqlColumn>();
            if (column is not null)
                columnName = column.ColumnName;
            expressions.Add($"ALTER TABLE public.{tableName} ADD CONSTRAINT fk_{tableName}_{columnName}_{destName} FOREIGN KEY (\"{columnName}\")  REFERENCES public.{destName}(\"{identityName}\");");
        }
        string query = string.Join("\n", expressions);
        return connection.ExecuteAsync(query);
    }
}