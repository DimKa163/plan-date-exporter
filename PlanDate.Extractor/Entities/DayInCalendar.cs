using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record DayInCalendar : CreatioEntity
{
    [Index(Direction.ASC, false)]
    [Reference(typeof(DayType), "Id")]
    public Guid? DayTypeId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(DayOfWeek), "Id")]
    public Guid? DayOfWeekId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(Calendar), "Id")]
    public Guid? CalendarId { get; set; }
    
}