using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record NrbWarehouse : CreatioEntity
{
    [MaxLength(250)]
    [Index(Direction.ASC, false)]
    public string NrbFnrec { get; set; } = null!;
    [MaxLength(50)]
    [Index(Direction.ASC, false)]
    public string BpmDescriptorGroupName { get; set; } = null!;
    [MaxLength(250)]
    public string NrbAddress { get; set; } = null!;
    [Index(Direction.ASC, false)]
    [Reference(typeof(TimeZone), "Id")]
    public Guid? AskTimeZoneId { get; set; }
}