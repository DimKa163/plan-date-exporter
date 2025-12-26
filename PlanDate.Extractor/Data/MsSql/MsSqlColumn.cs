namespace PlanDate.Extractor.Data.MsSql;
[AttributeUsage(AttributeTargets.Property)]
public class MsSqlColumn(string columnName) : Attribute
{
    public string ColumnName => columnName;
}