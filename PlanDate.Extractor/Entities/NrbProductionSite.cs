namespace PlanDate.Extractor.Entities;

public record NrbProductionSite : CreatioEntity
{
    public string Name { get; set; } = null!;
    public string BpmCode { get; set; } = null!;
    public string Description { get; set; } = null!;

    public TimeSpan? CutOffTime { get; set; }

    public Guid? NrbCalendarId { get; set; }
    public Guid? NrbSubWarehouseId { get; set; }
}