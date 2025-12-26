namespace PlanDate.Extractor.Entities;

public record DeliveryType : CreatioEntity
{
    public string NrbFNREC { get; set; } = null!;
    
    public string Name { get; set; } = null!;
}