namespace PlanDate.Extractor.Entities;

public record NrbStandardPurchase : CreatioEntity
{
    /// <summary>
    /// Идентефикатор поставщика
    /// </summary>
    public Guid? NrbAccountProviderId { get;  set; }

    /// <summary>
    /// Интеграционный идентификатор
    /// </summary>
    public Guid? NrbIntegrationId { get; set; }

    /// <summary>
    /// Назвние
    /// </summary>
    public string NrbName { get; set; } = null!;

    /// <summary>
    /// Заметки
    /// </summary>
    public string NrbNotes { get; set; } = null!;

    /// <summary>
    /// Срок поставки
    /// </summary>
    public int NrbTermOfDelivery { get; set; }


    public bool NrbMonday { get; set; }
    public bool NrbTuesday { get; set; }
    public bool NrbWednesday { get; set; }
    public bool NrbThursday { get; set; }
    public bool NrbFriday { get; set; }
    public bool NrbSaturday { get; set; }
    public bool NrbSunday { get; set; }

    public TimeSpan? CutOffTime { get; set; }
}