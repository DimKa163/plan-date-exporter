using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;

[NpgsqlTable("working_time_interval")]
public record WorkingTimeInterval : CreatioEntity
{
    [Index(Direction.ASC, false)]
    [Reference(typeof(DayInCalendar))]
    [NpgsqlColumn("day_in_calendar_id")]
    public Guid? DayInCalendarId { get; set; }

    [NpgsqlColumn("from_time")]
    public TimeSpan? From { get; set; }

    [NpgsqlColumn("to_time")]
    public TimeSpan? To { get; set; }
}