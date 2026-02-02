using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;
[NpgsqlTable("nrb_norm_status")]
public record NrbNormStatus : CreatioEntity
{
    [NpgsqlColumn("nrb_days_of_execution")]
    public int NrbDaysOfExecution { get; set; }
    [MaxLength(50)]
    [NpgsqlColumn("nrb_descriptor_group_name")]
    public string NrbDescriptorGroupName { get; set; } = null!;
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("nrb_delivery_type_id")]
    [Reference(typeof(DeliveryType))]
    public Guid? NrbDeliveryTypeId { get; set; } = null!;
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("nrb_order_status_id")]
    public Guid? NrbOrderStatusId { get; set; } = null!; 
}