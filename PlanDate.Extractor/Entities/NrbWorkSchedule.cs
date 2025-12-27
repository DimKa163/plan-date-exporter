using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record NrbWorkSchedule : CreatioEntity
{
    [Index(Direction.ASC, false)]
    [Reference(typeof(Calendar), "Id")]
    public Guid? NrbCalendarId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse), "Id")]
    public Guid? NrbSubWarehouseId { get; set; }
    [Index(Direction.ASC, false)]
    public Guid? NrbTypeWorkScheduleId { get; set; }
    
    public TimeSpan? CutOffTime { get; set; }
}