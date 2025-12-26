namespace PlanDate.Extractor.Entities;

public record DayOff : CreatioEntity
{
    public Guid? CalendarId { get; set; }
    
    public Guid? DayTypeId { get; set; }
    
    public DateTime? Date { get; set; }
    
    public bool IsRepeated { get; set; }
}