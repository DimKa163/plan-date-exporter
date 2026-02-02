using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;

[NpgsqlTable("nrb_warehouse")]
public record NrbWarehouse : CreatioEntity
{
    [MaxLength(250)]
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("nrb_fnrec")]
    public string NrbFnrec { get; set; } = null!;

    [MaxLength(50)]
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("bpm_descriptor_group_name")]
    public string BpmDescriptorGroupName { get; set; } = null!;

    [MaxLength(250)]
    [NpgsqlColumn("nrb_address")]
    public string NrbAddress { get; set; } = null!;

    [Index(Direction.ASC, false)]
    [Reference(typeof(TimeZone))]
    [NpgsqlColumn("ask_time_zone_id")]
    public Guid? AskTimeZoneId { get; set; }
}