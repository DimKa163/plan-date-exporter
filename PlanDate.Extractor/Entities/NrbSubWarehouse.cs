using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record NrbSubWarehouse : CreatioEntity
{
    [MaxLength(50)]
    [Index(Direction.ASC, false)]
    public string NrbFNrec { get; set; } = null!;
    [MaxLength(250)]
    public string NrbName { get; set; } = null!;

    public bool NrbIsActive { get; set; }
    public bool BpmOnlyStockPickupAllowed { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse), "Id")]
    public Guid? NrbSenderId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse), "Id")]
    public Guid? NrbRecipientId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbWarehouse), "Id")]
    public Guid? NrbWarehouseId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouseCategories), "Id")]
    public Guid? NrbCategoryId { get; set; }
}