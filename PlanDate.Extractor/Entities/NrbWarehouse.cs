namespace PlanDate.Extractor.Entities;

public record NrbWarehouse : CreatioEntity
{
    public string NrbFnrec { get; set; } = null!;
    public string BpmDescriptorGroupName { get; set; } = null!;
    public string NrbAddress { get; set; } = null!;

    public Guid? AskTimeZoneId { get; set; }
}