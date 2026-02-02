using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;
[NpgsqlTable("nrb_production_site")]
public record NrbProductionSite : CreatioEntity
{
    [MaxLength(50)]
    [NpgsqlColumn("name")]
    public string Name { get; set; } = null!;

    [MaxLength(50)]
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("bpm_code")]
    public string BpmCode { get; set; } = null!;

    [MaxLength(500)]
    [NpgsqlColumn("description")]
    public string Description { get; set; } = null!;

    [NpgsqlColumn("cut_off_time")]
    public TimeSpan? CutOffTime { get; set; }

    [Index(Direction.ASC, false)]
    [Reference(typeof(Calendar))]
    [NpgsqlColumn("nrb_calendar_id")]
    public Guid? NrbCalendarId { get; set; }

    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse))]
    [NpgsqlColumn("nrb_sub_warehouse_id")]
    public Guid? NrbSubWarehouseId { get; set; }
}