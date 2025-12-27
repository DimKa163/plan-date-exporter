using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record NrbSubWarehouseCategories : CreatioEntity
{
    [MaxLength(200)]
    [Index(Direction.ASC, false)]
    public string NrbFNREC { get; set; } = null!;
    public bool NrbAvailableForBalances { get; set; }
}