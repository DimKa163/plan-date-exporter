namespace PlanDate.Extractor.Data;

[AttributeUsage(AttributeTargets.Property)]
public class Reference(Type type) : Attribute
{
    public Type Type => type;
}