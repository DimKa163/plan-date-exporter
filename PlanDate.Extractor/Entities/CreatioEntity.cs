using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.MsSql;

namespace PlanDate.Extractor.Entities;

public abstract record CreatioEntity
{
    [MsSqlColumn("Id")]
    [Identity]
    public Guid Id { get; set; }
}