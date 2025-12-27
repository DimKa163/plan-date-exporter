using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record BpmReservationsStopLists : CreatioEntity
{
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse), "Id")]
    public Guid? BpmSubWarehouseId { get; set; }
    [MaxLength(500)]
    [Index(Direction.ASC, false)]
    public string BpmDescriptorsGroup { get; set; } = null!; 
}