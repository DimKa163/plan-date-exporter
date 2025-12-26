namespace PlanDate.Extractor.Entities;

public record TimeZone : CreatioEntity
{
    public string Code { get; set; } = null!;
}