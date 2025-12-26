namespace PlanDate.Extractor.Entities;

public record ProductDeficit : CreatioEntity
{
    public Guid ProductId { get; set; }
    public DateTime? PurchaseDate { get; set; }
        
    public Guid? BpmIntegrationId { get; set; }
}