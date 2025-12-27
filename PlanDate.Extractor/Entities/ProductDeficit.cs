using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record ProductDeficit : CreatioEntity
{
    [Index(Direction.ASC, false)]
    [Reference(typeof(Product), "Id")]
    public Guid ProductId { get; set; }
    
    public DateTime? PurchaseDate { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse), "Id")]
    public Guid? BpmSubWarehouseId { get; set; }
}