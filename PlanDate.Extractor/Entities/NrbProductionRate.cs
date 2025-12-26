namespace PlanDate.Extractor.Entities;

public record NrbProductionRate : CreatioEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid? NrbGroupId { get; set; }
    public Guid? NrbSeriesId { get; set; }

    public Guid? NrbProductionSiteId { get; set; }
    public int NrbProductionDays { get; set; }
    public int NrbDelayDays { get; set; }
}