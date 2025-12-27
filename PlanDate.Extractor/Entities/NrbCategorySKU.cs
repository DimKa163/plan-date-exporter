using System.ComponentModel.DataAnnotations;

namespace PlanDate.Extractor.Entities;

public record NrbCategorySKU : CreatioEntity
{
    [MaxLength(250)]
    public string Name { get; set; } = null!;
}