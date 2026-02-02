using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;

[NpgsqlTable("nrb_standard_purchase")]
public record NrbStandardPurchase : CreatioEntity
{
    /// <summary>
    /// Идентефикатор поставщика
    /// </summary>
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("nrb_account_provider_id")]
    public Guid? NrbAccountProviderId { get; set; }

    /// <summary>
    /// Интеграционный идентификатор
    /// </summary>
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("nrb_integration_id")]
    public Guid? NrbIntegrationId { get; set; }

    /// <summary>
    /// Назвние
    /// </summary>
    [MaxLength(250)]
    [NpgsqlColumn("nrb_name")]
    public string NrbName { get; set; } = null!;

    /// <summary>
    /// Заметки
    /// </summary>
    [MaxLength(500)]
    [NpgsqlColumn("nrb_notes")]
    public string NrbNotes { get; set; } = null!;

    /// <summary>
    /// Срок поставки
    /// </summary>
    [NpgsqlColumn("nrb_term_of_delivery")]
    public int NrbTermOfDelivery { get; set; }

    [NpgsqlColumn("nrb_monday")]
    public bool NrbMonday { get; set; }

    [NpgsqlColumn("nrb_tuesday")]
    public bool NrbTuesday { get; set; }

    [NpgsqlColumn("nrb_wednesday")]
    public bool NrbWednesday { get; set; }

    [NpgsqlColumn("nrb_thursday")]
    public bool NrbThursday { get; set; }

    [NpgsqlColumn("nrb_friday")]
    public bool NrbFriday { get; set; }

    [NpgsqlColumn("nrb_saturday")]
    public bool NrbSaturday { get; set; }

    [NpgsqlColumn("nrb_sunday")]
    public bool NrbSunday { get; set; }

    [NpgsqlColumn("cut_off_time")]
    public TimeSpan? CutOffTime { get; set; }
}