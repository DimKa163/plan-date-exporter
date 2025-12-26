namespace PlanDate.Extractor.Entities;

public record NrbRelatedProduct : CreatioEntity
{
    /// <summary>
    /// Количество
    /// </summary>
    public int NrbAmountMV { get; set; }

    public Guid? NrbProductSKUId { get; set; }

    public Guid? NrbProductMVId { get; set; }
}