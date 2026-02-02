using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;
[NpgsqlTable("calendar")]
public record Calendar : CreatioEntity
{
    [NpgsqlColumn("around_clock")]
    public bool AroundClock { get; set; }
    [NpgsqlColumn("without_day_off")]
    public bool WithoutDayOff { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(TimeZone))]
    [NpgsqlColumn("timezone_id")]
    public Guid? TimeZoneId { get; set; }
}