using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record NrbProductionRate : CreatioEntity
{
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    [MaxLength(500)]
    public string Description { get; set; } = null!;
    [Index(Direction.ASC, false)]
    public Guid? NrbGroupId { get; set; }
    [Index(Direction.ASC, false)]
    public Guid? NrbSeriesId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbProductionSite), "Id")]
    public Guid? NrbProductionSiteId { get; set; }
    public int NrbProductionDays { get; set; }
    public int NrbDelayDays { get; set; }
}