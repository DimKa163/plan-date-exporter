namespace PlanDate.Extractor.Entities;

public record Calendar : CreatioEntity
{
    public bool AroundClock { get; set; }
    
    public bool WithoutDayOff { get; set; }
    
    public Guid? TimeZoneId { get; set; }
}