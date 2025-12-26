using PlanDate.Extractor.Data.MsSql;

namespace PlanDate.Extractor.Entities;

public abstract record CreatioEntity
{
    [MsSqlColumn("Id")]
    public Guid Id { get; set; }
}