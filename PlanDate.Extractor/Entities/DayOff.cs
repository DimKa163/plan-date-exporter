using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record DayOff : CreatioEntity
{
    [Index(Direction.ASC, false)]
    [Reference(typeof(Calendar), "Id")]
    public Guid? CalendarId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(DayType), "Id")]
    public Guid? DayTypeId { get; set; }
    
    public DateTime? Date { get; set; }
    [Index(Direction.ASC, false)]
    public bool IsRepeated { get; set; }
}