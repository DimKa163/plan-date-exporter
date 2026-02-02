using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;

[NpgsqlTable("nrb_sub_warehouse_categories")]
public record NrbSubWarehouseCategories : CreatioEntity
{
    [MaxLength(200)]
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("nrb_fnrec")]
    public string NrbFNREC { get; set; } = null!;

    [NpgsqlColumn("nrb_available_for_balances")]
    public bool NrbAvailableForBalances { get; set; }
}