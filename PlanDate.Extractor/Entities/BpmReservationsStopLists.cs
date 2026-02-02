using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;
[NpgsqlTable("bpm_reservations_stop_lists")]
public record BpmReservationsStopLists : CreatioEntity
{
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse))]
    [NpgsqlColumn("bpm_sub_warehouse_id")]
    public Guid? BpmSubWarehouseId { get; set; }
    [MaxLength(500)]
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("bpm_descriptors_group")]
    public string BpmDescriptorsGroup { get; set; } = null!; 
}