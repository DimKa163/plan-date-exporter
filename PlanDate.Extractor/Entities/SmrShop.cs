namespace PlanDate.Extractor.Entities;

public record SmrShop : CreatioEntity
{
    public string SmrNrec { get; set; } = null!;

    public Guid? NrbWarehouseId { get; set; }
}