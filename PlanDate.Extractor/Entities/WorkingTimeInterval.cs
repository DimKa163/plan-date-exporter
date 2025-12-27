using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record WorkingTimeInterval : CreatioEntity
{
    [Index(Direction.ASC, false)]
    [Reference(typeof(DayInCalendar), "Id")]
    public Guid? DayInCalendarId { get; set; }
    public TimeSpan? From { get; set; }
    public TimeSpan? To { get; set; }
}