using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;

[NpgsqlTable("product_deficit")]
public record ProductDeficit : CreatioEntity
{
    [Index(Direction.ASC, false)]
    [Reference(typeof(Product))]
    [NpgsqlColumn("product_id")]
    public Guid ProductId { get; set; }

    [NpgsqlColumn("purchase_date")]
    public DateTime? PurchaseDate { get; set; }

    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse))]
    [NpgsqlColumn("bpm_sub_warehouse_id")]
    public Guid? BpmSubWarehouseId { get; set; }
}