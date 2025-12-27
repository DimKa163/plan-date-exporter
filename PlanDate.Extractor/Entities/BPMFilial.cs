using System.ComponentModel.DataAnnotations;
using PlanDate.Extractor.Data;

namespace PlanDate.Extractor.Entities;

public record BPMFilial : CreatioEntity
{
    [MaxLength(50)]
    [Index(Direction.ASC, true)]
    public string BpmCode { get; set; } = null!;
}