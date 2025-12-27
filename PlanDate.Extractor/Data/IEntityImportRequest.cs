using Microsoft.Data.SqlClient;

namespace PlanDate.Extractor.Data;

public interface IEntityImportRequest
{
    Task ImportAsync(SqlConnection connection, object model, CancellationToken token = default);
}