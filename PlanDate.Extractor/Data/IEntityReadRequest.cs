using Microsoft.Data.SqlClient;
using PlanDate.Extractor.Entities;

namespace PlanDate.Extractor.Data;

public interface IEntityReadRequest<TEntity> where TEntity : CreatioEntity
{
    IAsyncEnumerable<TEntity> ReadAsync(SqlConnection connection, CancellationToken token = default);
}