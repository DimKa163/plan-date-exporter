using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record NrbTransportLeg : CreatioEntity
{
    [MaxLength(250)]
    public string NrbName { get; set; } = null!;

    /// <summary>
    /// Идентефикатор МОЛа откуда
    /// </summary>
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse), "Id")]
    public Guid? NrbSubWarehouseId { get; set; }

    /// <summary>
    /// Идентефикатор МОЛа куда
    /// </summary>
    [Index(Direction.ASC, false)]
    [Reference(typeof(NrbSubWarehouse), "Id")]
    public Guid? NrbSubWarehouseWhereId { get; set; }

    /// <summary>
    /// Норма перемещения в днях
    /// </summary>
    public int NrbStandardMoving { get; set; }

    /// <summary>
    /// Дней на автоматическое резервирование и хрен пойми что
    /// </summary>
    public int BpmAddDays { get; set; }

    /// <summary>
    /// Время крайнего срока (отсечки)
    /// </summary>
    public TimeSpan? NrbCutOffTime { get; set; }

    /// <summary>
    /// Идентефикатор дня отсечки
    /// </summary>
    [Index(Direction.ASC, false)]
    public Guid? NrbCutOffDayId { get; set; }

    public bool NrbShipmentMonday { get; set; }
    public bool NrbShipmentTuesday { get; set; }
    public bool NrbShipmentWednesday { get; set; }
    public bool NrbShipmentThursday { get; set; }
    public bool NrbShipmentFriday { get; set; }
    public bool NrbShipmentSaturday { get; set; }
    public bool NrbShipmentSunday { get; set; }
}