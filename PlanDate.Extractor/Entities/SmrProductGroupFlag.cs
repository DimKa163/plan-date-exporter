using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;
[NpgsqlTable("smr_product_group_flag")]
public record SmrProductGroupFlag : CreatioEntity
{
    [NpgsqlColumn("name")]
    public string Name { get; set; }
    [NpgsqlColumn("smr_fnrec")]
    [MaxLength(50)]
    [Index(Direction.ASC, false)]
    public string SmrFNREC { get; set; }
    [NpgsqlColumn("bpm_integration_id")]
    [Index(Direction.ASC, false)]
    public Guid? BpmIntegrationId { get; set; }
}