namespace PlanDate.Extractor.Entities;

public record WorkingTimeInterval : CreatioEntity
{
    public Guid? DayInCalendarId { get; set; }
    public TimeSpan? From { get; set; }
    public TimeSpan? To { get; set; }
}