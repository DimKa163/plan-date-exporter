using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;

[NpgsqlTable("smr_shop")]
public record SmrShop : CreatioEntity
{
    [MaxLength(50)]
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("smr_fnrec")]
    public string SmrFnrec { get; set; } = null!;

    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbWarehouse))]
    [NpgsqlColumn("nrb_warehouse_id")]
    public Guid? NrbWarehouseId { get; set; }
}