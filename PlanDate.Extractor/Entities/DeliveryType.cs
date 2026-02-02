using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;
[NpgsqlTable("delivery_type")]
public record DeliveryType : CreatioEntity
{
    [MaxLength(50)]
    [Index(Direction.ASC, true)]
    [NpgsqlColumn("nrb_fnrec")]
    public string NrbFNREC { get; set; } = null!;
    [MaxLength(50)]
    [NpgsqlColumn("name")]
    public string Name { get; set; } = null!;
}