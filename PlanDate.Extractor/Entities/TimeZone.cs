using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;

[NpgsqlTable("time_zone")]
public record TimeZone : CreatioEntity
{
    [MaxLength(50)]
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("code")]
    public string Code { get; set; } = null!;
}