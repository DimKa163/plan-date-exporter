using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace PlanDate.Extractor.Data;

public interface IEntityRequest
{
    Task ExecuteAsync(DbConnection connection, Type type, CancellationToken token = default);
}