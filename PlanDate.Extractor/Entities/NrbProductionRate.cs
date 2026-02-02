using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;
[NpgsqlTable("nrb_production_rate")]
public record NrbProductionRate : CreatioEntity
{
    [MaxLength(50)]
    [NpgsqlColumn("name")]
    public string Name { get; set; } = null!;
    [MaxLength(500)]
    [NpgsqlColumn("description")]
    public string Description { get; set; } = null!;
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("nrb_group_id")]
    public Guid? NrbGroupId { get; set; }
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("nrb_series_id")]
    public Guid? NrbSeriesId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbProductionSite))]
    [NpgsqlColumn("nrb_production_site_id")]
    public Guid? NrbProductionSiteId { get; set; }
    [NpgsqlColumn("nrb_production_days")]
    public int NrbProductionDays { get; set; }
    [NpgsqlColumn("nrb_delay_days")]
    public int NrbDelayDays { get; set; }
}