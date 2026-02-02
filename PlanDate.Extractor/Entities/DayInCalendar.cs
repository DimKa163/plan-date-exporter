using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;
[NpgsqlTable("day_in_calendar")]
public record DayInCalendar : CreatioEntity
{
    [Index(Direction.ASC, false)]
    [Reference(typeof(DayType))]
    [NpgsqlColumn("day_type_id")]
    public Guid? DayTypeId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(DayOfWeek))]
    [NpgsqlColumn("day_of_week_id")]
    public Guid? DayOfWeekId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(Calendar))]
    [NpgsqlColumn("calendar_id")]
    public Guid? CalendarId { get; set; }
    
}