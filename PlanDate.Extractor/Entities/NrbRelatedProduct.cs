using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record NrbRelatedProduct : CreatioEntity
{
    /// <summary>
    /// Количество
    /// </summary>
    public int NrbAmountMV { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(Product), "Id")]
    public Guid? NrbProductSKUId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(Product), "Id")]
    public Guid? NrbProductMVId { get; set; }
}