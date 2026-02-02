namespace PlanDate.Extractor.Data.Npgsql;
[AttributeUsage(AttributeTargets.Property)]
public class NpgsqlColumn(string columnName) : Attribute
{
    public string ColumnName => columnName;
}