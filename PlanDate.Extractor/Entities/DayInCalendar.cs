namespace PlanDate.Extractor.Entities;

public record DayInCalendar : CreatioEntity
{
    public Guid? DayTypeId { get; set; }
    
    public Guid? DayOfWeekId { get; set; }
    
    public Guid? CalendarId { get; set; }
    
}