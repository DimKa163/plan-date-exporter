using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;
[NpgsqlTable("day_off")]
public record DayOff : CreatioEntity
{
    [Index(Direction.ASC, false)]
    [Reference(typeof(Calendar))]
    [NpgsqlColumn("calendar_id")]
    public Guid? CalendarId { get; set; }
    [Index(Direction.ASC, false)]
    [Reference(typeof(DayType))]
    [NpgsqlColumn("day_type_id")]
    public Guid? DayTypeId { get; set; }
    [NpgsqlColumn("date")]
    public DateTime? Date { get; set; }
    [NpgsqlColumn("is_repeated")]
    public bool IsRepeated { get; set; }
}