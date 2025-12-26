using Microsoft.Data.SqlClient;
using PlanDate.Extractor.Entities;

namespace PlanDate.Extractor.Data;

public interface IEntityReaderRequest<TEntity> where TEntity : CreatioEntity
{
    IAsyncEnumerable<TEntity> ReadAsync(SqlConnection connection, CancellationToken token = default);
}