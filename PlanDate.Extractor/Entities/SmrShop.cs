using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record SmrShop : CreatioEntity
{
    [MaxLength(50)]
    [Index(Direction.ASC, true)]
    public string SmrFnrec { get; set; } = null!;
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbWarehouse), "Id")]
    public Guid? NrbWarehouseId { get; set; }
}