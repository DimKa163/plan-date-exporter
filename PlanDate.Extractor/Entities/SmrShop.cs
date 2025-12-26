namespace PlanDate.Extractor.Entities;

public record SmrShop : CreatioEntity
{
    public string SmrFnrec { get; set; } = null!;

    public Guid? NrbWarehouseId { get; set; }
}