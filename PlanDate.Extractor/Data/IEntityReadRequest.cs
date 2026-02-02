using System.Data.Common;
using PlanDate.Extractor.Entities;

namespace PlanDate.Extractor.Data;

public interface IEntityReadRequest<TEntity> where TEntity : CreatioEntity
{
    IAsyncEnumerable<TEntity> ReadAsync(DbConnection connection, CancellationToken token = default);
}