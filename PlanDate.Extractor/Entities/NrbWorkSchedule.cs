namespace PlanDate.Extractor.Entities;

public record NrbWorkSchedule : CreatioEntity
{
    public Guid? NrbCalendarId { get; set; }
    public Guid? NrbSubWarehouseId { get; set; }
    public Guid? NrbTypeWorkScheduleId { get; set; }
    public TimeSpan? CutOffTime { get; set; }
}