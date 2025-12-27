using Microsoft.Data.SqlClient;

namespace PlanDate.Extractor.Data;

public interface IEntityRequest
{
    Task ExecuteAsync(SqlConnection connection, Type type, CancellationToken token = default);
}