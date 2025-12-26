namespace PlanDate.Extractor.Entities;

public record NrbSubWarehouseCategories : CreatioEntity
{
    public string NrbFNREC { get; set; } = null!;
    public bool NrbAvailableForBalances { get; set; }
}