using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record NrbNormStatus : CreatioEntity
{
    public int NrbDaysOfExecution { get; set; }
    [MaxLength(50)]
    public string NrbDescriptorGroupName { get; set; } = null!;
    [Index(Direction.ASC, false)]
    [Reference(typeof(DeliveryType), "Id")]
    public Guid? NrbDeliveryTypeId { get; set; } = null!;
    [Index(Direction.ASC, false)]
    public Guid? NrbOrderStatusId { get; set; } = null!; 
}