using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record TimeZone : CreatioEntity
{
    [MaxLength(50)]
    [Index(Direction.ASC, false)]
    public string Code { get; set; } = null!;
}