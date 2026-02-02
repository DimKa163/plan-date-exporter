using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;

[NpgsqlTable("product")]
public record Product : CreatioEntity
{
    /// <summary>
    /// Fnrec
    /// </summary>
    [MaxLength(50)]
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("smr_fnrec")]
    public string SmrFNREC { get; set; } = null!;

    [MaxLength(250)]
    [NpgsqlColumn("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Является услугой
    /// </summary>
    [NpgsqlColumn("smr_is_service")]
    public bool SmrIsService { get; set; }

    /// <summary>
    /// Признак архивности
    /// </summary>
    [NpgsqlColumn("is_archive")]
    public bool IsArchive { get; set; }

    /// <summary>
    /// Объем за штуку
    /// </summary>
    [NpgsqlColumn("ask_pack_volume")]
    public decimal AskPackVolume { get; set; }

    [NpgsqlColumn("ask_weight")]
    public decimal AskWeight { get; set; }

    [NpgsqlColumn("ask_pack_length")]
    public decimal AskPackLength { get; set; }

    [NpgsqlColumn("ask_pack_width")]
    public decimal AskPackWidth { get; set; }

    [NpgsqlColumn("ask_pack_height")]
    public decimal AskPackHeight { get; set; }

    /// <summary>
    /// Серия
    /// </summary>
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("smr_series_id")]
    public Guid? SmrSeriesId { get; set; }

    [Index(Direction.ASC, false)]
    [NpgsqlColumn("type_id")]
    public Guid? TypeId { get; set; }

    [Index(Direction.ASC, false)]
    [NpgsqlColumn("nrb_status_sku_id")]
    public Guid? NrbStatusSKUId { get; set; }

    [Index(Direction.ASC, false)]
    [NpgsqlColumn("nrb_type_production_id")]
    public Guid? NrbTypeProductionId { get; set; }

    /// <summary>
    /// Группа/категория
    /// </summary>
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("category_id")]
    public Guid? CategoryId { get; set; }

    /// <summary>
    /// Основной поставщик
    /// </summary>
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("nrb_account_product_id")]
    public Guid? NrbAccountProductId { get; set; }

    /// <summary>
    /// Категория нестандарта
    /// </summary>
    [Index(Direction.ASC, false)]
    [Reference(typeof(AskNonStandartCategory))]
    [NpgsqlColumn("ask_non_standart_category_id")]
    public Guid? AskNonStandartCategoryId { get; set; }
    /// <summary>
    /// Группа продукта
    /// </summary>
    [Index(Direction.ASC, false)]
    [Reference(typeof(SmrProductGroupFlag))]
    [NpgsqlColumn("smr_product_group_flag_id")]
    public Guid? SmrProductGroupFlagId { get; set; }

    /// <summary>
    /// Интеграционный идентификатор
    /// </summary>
    [MaxLength(50)]
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("nrb_integration_id")]
    public string NrbIntegrationId { get; set; } = null!;

    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbCategorySKU))]
    [NpgsqlColumn("nrb_category_sku_id")]
    public Guid? NrbCategorySKUId { get; set; }

    /// <summary>
    /// Кол-во связанных МЦ
    /// </summary>
    [NpgsqlColumn("nrb_count_mv")]
    public int NrbCountMV { get; set; }
    
    [NpgsqlColumn("bpm_is_matrix")]
    public bool BpmIsMatrix { get; set; }
}
