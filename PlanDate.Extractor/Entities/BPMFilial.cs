using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;
[NpgsqlTable("bpm_filial")]
public record BPMFilial : CreatioEntity
{
    [MaxLength(50)]
    [Index(Direction.ASC, true)]
    [NpgsqlColumn("bpm_code")]
    public string BpmCode { get; set; } = null!;
}