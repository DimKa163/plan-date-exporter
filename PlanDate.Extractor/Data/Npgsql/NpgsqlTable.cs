namespace PlanDate.Extractor.Data.Npgsql;
[AttributeUsage(AttributeTargets.Class)]
public class NpgsqlTable(string tableName) : Attribute
{
    public string TableName => tableName;
}