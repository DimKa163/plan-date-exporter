namespace PlanDate.Extractor.Entities;

public record NrbProductBalances : CreatioEntity
{
    public Guid? NrbProductId { get; set; }

    public Guid? NrbSubWarehouseId { get; set; }

    public Guid? BpmFilialId { get; set; }

    public string NrbIntegrationId { get; set; } = null!;

    /// <summary>
    /// Текущий остаток
    /// </summary>
    public decimal NrbQuantity { get; set; }
}