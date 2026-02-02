using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;
[NpgsqlTable("nrb_configurator")]
public record NrbConfigurator : CreatioEntity
{
    [NpgsqlColumn("nrb_production_site_id")]
    public Guid? NrbProductionSiteId { get; set; }

    /// <summary>
    /// Срок закупки/производства по умолчанию.
    /// </summary>
    [NpgsqlColumn("nrb_defalut_product_produce_days")]
    public int NrbDefalutProductProduceDays { get; set; }

    /// <summary>
    /// Количество предлагаемых вариантов доставки.
    /// </summary>
    [NpgsqlColumn("nrb_delivery_variants_offer")]
    public int NrbDeliveryVariantsOffer { get; set; }

    [NpgsqlColumn("nrb_puechase_sub_sarehouse_id")]
    public Guid? NrbPuechaseSubSarehouseId { get; set; }
}