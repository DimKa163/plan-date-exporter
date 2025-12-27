namespace PlanDate.Extractor.Data;
[AttributeUsage(AttributeTargets.Property)]
public class IndexAttribute(Direction direction, bool unique) : Attribute
{
    public Direction Direction => direction;
    
    public bool Unique => unique;
}
public enum Direction
{
    ASC,
    DESC
}