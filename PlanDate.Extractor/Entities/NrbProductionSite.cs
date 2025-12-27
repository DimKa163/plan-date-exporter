using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record NrbProductionSite : CreatioEntity
{
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    [MaxLength(50)]
    [Index(Direction.ASC, false)]
    public string BpmCode { get; set; } = null!;
    [MaxLength(500)]
    public string Description { get; set; } = null!;

    public TimeSpan? CutOffTime { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(Calendar), "Id")]
    public Guid? NrbCalendarId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse), "Id")]
    public Guid? NrbSubWarehouseId { get; set; }
}