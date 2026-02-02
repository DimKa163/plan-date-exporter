using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using PlanDate.Extractor.Entities;

namespace PlanDate.Extractor.Data;

public class Executor(DbConnection connection)
{
    public IAsyncEnumerable<TEntity> ReadAsync<TEntity>(IEntityReadRequest<TEntity> request, CancellationToken token = default)
        where TEntity : CreatioEntity
    {
        if (connection.State != ConnectionState.Open)
            throw new InvalidOperationException("The connection should be opened");
        return request.ReadAsync(connection, token);
    }

    public Task ExecuteAsync(IEntityImportRequest request, object model, CancellationToken token = default)
    {
        if (connection.State != ConnectionState.Open)
            throw new InvalidOperationException("The connection should be opened");
        return request.ImportAsync(connection, model, token);
    }
    
    public Task ExecuteAsync(IMultipleEntityImportRequest request, IEnumerable<object> model, CancellationToken token = default)
    {
        if (connection.State != ConnectionState.Open)
            throw new InvalidOperationException("The connection should be opened");
        return request.ImportAsync(connection, model, token);
    }

    public Task ExecuteAsync(IEntityRequest request, Type type, CancellationToken token = default)
    {
        if (connection.State != ConnectionState.Open)
            throw new InvalidOperationException("The connection should be opened");
        return request.ExecuteAsync(connection, type, token);
    }
}