using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;

[NpgsqlTable("nrb_transport_leg")]
public record NrbTransportLeg : CreatioEntity
{
    [MaxLength(250)]
    [NpgsqlColumn("nrb_name")]
    public string NrbName { get; set; } = null!;

    /// <summary>
    /// Идентефикатор МОЛа откуда
    /// </summary>
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse))]
    [NpgsqlColumn("nrb_sub_warehouse_id")]
    public Guid? NrbSubWarehouseId { get; set; }

    /// <summary>
    /// Идентефикатор МОЛа куда
    /// </summary>
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse))]
    [NpgsqlColumn("nrb_sub_warehouse_where_id")]
    public Guid? NrbSubWarehouseWhereId { get; set; }

    /// <summary>
    /// Норма перемещения в днях
    /// </summary>
    [NpgsqlColumn("nrb_standard_moving")]
    public int NrbStandardMoving { get; set; }

    /// <summary>
    /// Дней на автоматическое резервирование и хрен пойми что
    /// </summary>
    [NpgsqlColumn("bpm_add_days")]
    public int BpmAddDays { get; set; }

    /// <summary>
    /// Время крайнего срока (отсечки)
    /// </summary>
    [NpgsqlColumn("nrb_cut_off_time")]
    public TimeSpan? NrbCutOffTime { get; set; }

    /// <summary>
    /// Идентефикатор дня отсечки
    /// </summary>
    [Index(Direction.ASC, false)]
    [NpgsqlColumn("nrb_cut_off_day_id")]
    public Guid? NrbCutOffDayId { get; set; }

    [NpgsqlColumn("nrb_shipment_monday")]
    public bool NrbShipmentMonday { get; set; }

    [NpgsqlColumn("nrb_shipment_tuesday")]
    public bool NrbShipmentTuesday { get; set; }

    [NpgsqlColumn("nrb_shipment_wednesday")]
    public bool NrbShipmentWednesday { get; set; }

    [NpgsqlColumn("nrb_shipment_thursday")]
    public bool NrbShipmentThursday { get; set; }

    [NpgsqlColumn("nrb_shipment_friday")]
    public bool NrbShipmentFriday { get; set; }

    [NpgsqlColumn("nrb_shipment_saturday")]
    public bool NrbShipmentSaturday { get; set; }

    [NpgsqlColumn("nrb_shipment_sunday")]
    public bool NrbShipmentSunday { get; set; }
}