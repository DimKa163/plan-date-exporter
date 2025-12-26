namespace PlanDate.Extractor.Data.MsSql;
[AttributeUsage(AttributeTargets.Class)]
public class MsSqlTable(string tableName) : Attribute
{
    public string TableName => tableName;
}