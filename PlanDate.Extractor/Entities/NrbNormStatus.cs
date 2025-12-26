namespace PlanDate.Extractor.Entities;

public record NrbNormStatus : CreatioEntity
{
    public int NrbDaysOfExecution { get; set; }
    public string NrbDescriptorGroupName { get; set; } = null!;
    public Guid? NrbDeliveryTypeId { get; set; } = null!;
    public Guid? NrbOrderStatusId { get; set; } = null!; 
}