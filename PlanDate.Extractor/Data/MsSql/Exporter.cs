using System.Reflection;
using Microsoft.Data.SqlClient;
using PlanDate.Extractor.Data.MsSql.Requests;
using PlanDate.Extractor.Entities;

namespace PlanDate.Extractor.Data.MsSql;

public class Exporter(Reader reader, Output output)
{
    public async Task ExportAsync(Func<Reader, Output, CancellationToken, Task>[] tasks, CancellationToken token)
    {
        foreach (var task in tasks)
        {
            await task(reader, output, token);
        }
    }
}
