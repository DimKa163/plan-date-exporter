using System.Data;
using Microsoft.Data.SqlClient;
using PlanDate.Extractor.Entities;

namespace PlanDate.Extractor.Data.MsSql;

public class Reader(SqlConnection connection)
{
    public IAsyncEnumerable<TEntity> ReadAsync<TEntity>(IEntityReaderRequest<TEntity> request, CancellationToken token = default)
        where TEntity : CreatioEntity
    {
        if (connection.State != ConnectionState.Open)
            throw new InvalidOperationException("The connection should be opened");
        return request.ReadAsync(connection, token);
    }
}