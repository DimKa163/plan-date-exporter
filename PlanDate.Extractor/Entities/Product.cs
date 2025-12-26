namespace PlanDate.Extractor.Entities;

public record Product : CreatioEntity
{
    /// <summary>
    /// Fnrec
    /// </summary>
    public string SmrFNREC { get; set; } = null!;
    public string Name { get; set; } = null!;

    /// <summary>
    /// Является услугой
    /// </summary>
    public bool SmrIsService { get; set; }

    /// <summary>
    /// Признак архивности
    /// </summary>
    public bool IsArchive { get; set; }

    /// <summary>
    /// Объем за штуку
    /// </summary>
    public decimal AskPackVolume { get; set; }
    public decimal AskWeight { get; set; }
    public decimal AskPackLength { get; set; }
    public decimal AskPackWidth { get;  set; }
    public decimal AskPackHeight { get; set; }

    /// <summary>
    /// Серия
    /// </summary>
    public Guid? SmrSeriesId { get; set; }
    public Guid? TypeId { get; set; }
    public Guid? NrbStatusSKUId { get; set; }
    public Guid? NrbTypeProductionId { get; set; }

    /// <summary>
    /// Группа/категория
    /// </summary>
    public Guid? CategoryId { get; set; }

    /// <summary>
    /// Основной поставщик
    /// </summary>
    public Guid? NrbAccountProductId { get; set; }

    /// <summary>
    /// Категория нестандарта
    /// </summary>
    public Guid? AskNonStandartCategoryId { get; set; }

    /// <summary>
    /// Интеграционный идентификатор
    /// </summary>
    public string NrbIntegrationId { get; set; } = null!;

    public Guid? NrbCategorySKUId { get; set; }

    /// <summary>
    /// Кол-во связанных МЦ
    /// </summary>
    public int NrbCountMV { get; set; }
}