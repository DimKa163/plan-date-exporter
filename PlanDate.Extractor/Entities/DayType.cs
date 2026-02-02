using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;
[NpgsqlTable("day_type")]
public record DayType : CreatioEntity
{
    [NpgsqlColumn("is_weekend")]
    public bool IsWeekend { get; set; }
    [NpgsqlColumn("non_working")]
    public bool NonWorking { get; set; }
}