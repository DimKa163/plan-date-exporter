namespace PlanDate.Extractor.Entities;

public record BpmReservationsStopLists : CreatioEntity
{
    public Guid BpmSubWarehouseId { get; set; }
    public string BpmDescriptorsGroup { get; set; } = null!; 
}