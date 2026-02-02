using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;

[NpgsqlTable("nrb_sub_warehouse")]
public record NrbSubWarehouse : CreatioEntity
{
    [MaxLength(50)]
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("nrb_fnrec")]
    public string NrbFNrec { get; set; } = null!;

    [MaxLength(250)]
    [NpgsqlColumn("nrb_name")]
    public string NrbName { get; set; } = null!;

    [NpgsqlColumn("nrb_is_active")]
    public bool NrbIsActive { get; set; }

    [NpgsqlColumn("bpm_only_stock_pickup_allowed")]
    public bool BpmOnlyStockPickupAllowed { get; set; }

    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse))]
    [NpgsqlColumn("nrb_sender_id")]
    public Guid? NrbSenderId { get; set; }

    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse))]
    [NpgsqlColumn("nrb_recipient_id")]
    public Guid? NrbRecipientId { get; set; }

    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbWarehouse))]
    [NpgsqlColumn("nrb_warehouse_id")]
    public Guid? NrbWarehouseId { get; set; }

    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouseCategories))]
    [NpgsqlColumn("nrb_category_id")]
    public Guid? NrbCategoryId { get; set; }
}