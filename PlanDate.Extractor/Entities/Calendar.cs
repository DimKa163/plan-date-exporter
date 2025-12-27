using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record Calendar : CreatioEntity
{
    public bool AroundClock { get; set; }
    
    public bool WithoutDayOff { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(TimeZone), "Id")]
    public Guid? TimeZoneId { get; set; }
}