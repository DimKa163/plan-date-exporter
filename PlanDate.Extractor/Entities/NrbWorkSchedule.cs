using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;

[NpgsqlTable("nrb_work_schedule")]
public record NrbWorkSchedule : CreatioEntity
{
    [Index(Direction.ASC, false)]
    [Reference(typeof(Calendar))]
    [NpgsqlColumn("nrb_calendar_id")]
    public Guid? NrbCalendarId { get; set; }

    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse))]
    [NpgsqlColumn("nrb_sub_warehouse_id")]
    public Guid? NrbSubWarehouseId { get; set; }

    [Index(Direction.ASC, false)]
    [NpgsqlColumn("nrb_type_work_schedule_id")]
    public Guid? NrbTypeWorkScheduleId { get; set; }

    [NpgsqlColumn("cut_off_time")]
    public TimeSpan? CutOffTime { get; set; }
}