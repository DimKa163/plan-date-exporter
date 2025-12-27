using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record DeliveryType : CreatioEntity
{
    [MaxLength(50)]
    [Index(Direction.ASC, false)]
    public string NrbFNREC { get; set; } = null!;
    [MaxLength(50)]
    public string Name { get; set; } = null!;
}