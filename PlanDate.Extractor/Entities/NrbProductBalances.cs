using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record NrbProductBalances : CreatioEntity
{
    [Index(Direction.ASC, false)]
    [Reference(typeof(Product), "Id")]
    public Guid? NrbProductId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse), "Id")]
    public Guid? NrbSubWarehouseId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(BPMFilial), "Id")]
    public Guid? BpmFilialId { get; set; }
    [MaxLength(50)]
    [Index(Direction.ASC, true)]
    public string NrbIntegrationId { get; set; } = null!;

    /// <summary>
    /// Текущий остаток
    /// </summary>
    public decimal NrbQuantity { get; set; }
}