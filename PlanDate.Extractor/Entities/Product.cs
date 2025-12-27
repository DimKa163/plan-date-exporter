using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record Product : CreatioEntity
{
    /// <summary>
    /// Fnrec
    /// </summary>
    [MaxLength(50)]
    [Index(Direction.ASC, false)]
    public string SmrFNREC { get; set; } = null!;
    [MaxLength(250)]
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
    [Index(Direction.ASC, false)]
    public Guid? SmrSeriesId { get; set; }
    [Index(Direction.ASC, false)]
    public Guid? TypeId { get; set; }
    [Index(Direction.ASC, false)]
    public Guid? NrbStatusSKUId { get; set; }
    [Index(Direction.ASC, false)]
    public Guid? NrbTypeProductionId { get; set; }

    /// <summary>
    /// Группа/категория
    /// </summary>
    [Index(Direction.ASC, false)]
    public Guid? CategoryId { get; set; }

    /// <summary>
    /// Основной поставщик
    /// </summary>
    [Index(Direction.ASC, false)]
    public Guid? NrbAccountProductId { get; set; }

    /// <summary>
    /// Категория нестандарта
    /// </summary>
    [Index(Direction.ASC, false)]
    [Reference(typeof(AskNonStandartCategory), "Id")]
    public Guid? AskNonStandartCategoryId { get; set; }

    /// <summary>
    /// Интеграционный идентификатор
    /// </summary>
    [MaxLength(50)]
    [Index(Direction.ASC, true)]
    public string NrbIntegrationId { get; set; } = null!;
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbCategorySKU), "Id")]
    public Guid? NrbCategorySKUId { get; set; }

    /// <summary>
    /// Кол-во связанных МЦ
    /// </summary>
    public int NrbCountMV { get; set; }
}