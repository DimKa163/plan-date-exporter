using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace PlanDate.Extractor.Data;

public interface IEntityImportRequest
{
    Task ImportAsync(DbConnection connection, object model, CancellationToken token = default);
}

public interface IMultipleEntityImportRequest
{
    Task ImportAsync(DbConnection connection, IEnumerable<object> model, CancellationToken token = default);
}