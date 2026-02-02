using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;
[NpgsqlTable("nrb_product_balances")]
public record NrbProductBalances : CreatioEntity
{
    [Index(Direction.ASC, false)]
    [Reference(typeof(Product))]
    [NpgsqlColumn("nrb_product_id")]
    public Guid? NrbProductId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse))]
    [NpgsqlColumn("nrb_sub_warehouse_id")]
    public Guid? NrbSubWarehouseId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(BPMFilial))]
    [NpgsqlColumn("bpm_filial_id")]
    public Guid? BpmFilialId { get; set; }
    [MaxLength(50)]
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("nrb_integration_id")]
    public string NrbIntegrationId { get; set; } = null!;

    /// <summary>
    /// Текущий остаток
    /// </summary>
    [NpgsqlColumn("nrb_quantity")]
    public decimal NrbQuantity { get; set; }
}