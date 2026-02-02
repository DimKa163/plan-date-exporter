using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;
[NpgsqlTable("nrb_related_product")]
public record NrbRelatedProduct : CreatioEntity
{
    /// <summary>
    /// Количество
    /// </summary>
    [NpgsqlColumn("nrb_amount_mv")]
    public int NrbAmountMV { get; set; }

    [Index(Direction.ASC, false)]
    [Reference(typeof(Product))]
    [NpgsqlColumn("nrb_product_sku_id")]
    public Guid? NrbProductSKUId { get; set; }

    [Index(Direction.ASC, false)]
    [Reference(typeof(Product))]
    [NpgsqlColumn("nrb_product_mv_id")]
    public Guid? NrbProductMVId { get; set; }
}