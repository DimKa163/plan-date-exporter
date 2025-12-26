namespace PlanDate.Extractor.Entities;

public record NrbConfigurator : CreatioEntity
{
    public Guid? NrbProductionSiteId { get; set; }

    /// <summary>
    /// Срок закупки/производства по умолчанию.
    /// </summary>
    public int NrbDefalutProductProduceDays { get; set; }

    /// <summary>
    /// Количество предлагаемых вариантов доставки.
    /// </summary>
    public int NrbDeliveryVariantsOffer { get; set; }


    public Guid? NrbPuechaseSubSarehouseId { get; set; }
}