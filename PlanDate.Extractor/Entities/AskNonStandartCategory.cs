using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;
[NpgsqlTable("ask_non_standart_category")]
public record AskNonStandartCategory : CreatioEntity
{
    [NpgsqlColumn("ask_add_days")]
    public int AskAddDays { get; set; }
}