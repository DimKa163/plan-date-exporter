namespace PlanDate.Extractor.Data;

[AttributeUsage(AttributeTargets.Property)]
public class Reference(Type type, string column) : Attribute
{
    public Type Type => type;
    
    public string ColumnName => column;
}