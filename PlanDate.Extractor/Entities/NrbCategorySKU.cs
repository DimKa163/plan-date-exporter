using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;
[NpgsqlTable("nrb_category_sku")]
public record NrbCategorySKU : CreatioEntity
{
    [MaxLength(250)]
    [NpgsqlColumn("name")]
    public string Name { get; set; } = null!;
}