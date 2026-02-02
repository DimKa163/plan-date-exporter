using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.MsSql;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Entities;

public abstract record CreatioEntity
{
    [MsSqlColumn("Id")]
    [NpgsqlColumn("id")]
    [Identity]
    public Guid Id { get; set; }
}