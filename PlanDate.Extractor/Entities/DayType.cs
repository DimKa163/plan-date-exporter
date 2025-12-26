namespace PlanDate.Extractor.Entities;

public record DayType : CreatioEntity
{
    public bool IsWeekend { get; set; }
    
    public bool NonWorking { get; set; }
}