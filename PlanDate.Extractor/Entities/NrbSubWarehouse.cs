namespace PlanDate.Extractor.Entities;

public record NrbSubWarehouse : CreatioEntity
{
    public string NrbFNrec { get; set; } = null!;
    public string NrbName { get; set; } = null!;

    public bool NrbIsActive { get; set; }
    public bool BpmOnlyStockPickupAllowed { get; set; }

    public Guid? NrbSenderId { get; set; }
    public Guid? NrbRecipientId { get; set; }

    public Guid? NrbWarehouseId { get; set; }

    public Guid? NrbCategoryId { get; set; }
}