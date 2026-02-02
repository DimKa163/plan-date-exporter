using System.Reflection;
using System.Text.Json;
using PlanDate.Extractor.Data.MsSql.Requests;
using PlanDate.Extractor.Entities;

namespace PlanDate.Extractor.Data.MsSql;

public class MsSqlImporter(Executor executor, Input input) : IImporter
{
    public async Task ImportAsync(CancellationToken ct)
    {
        var assembly = Assembly.GetEntryAssembly();
        if (assembly is null)
            throw new InvalidOperationException("The assembly should not be null");
        var mapTypes = assembly.GetTypes().Where(x => !x.IsAbstract && x.BaseType == typeof(CreatioEntity)).ToDictionary(x => x.Name);
        Queue<Type> processed = new Queue<Type>();
        Type? entityType = null;
        await foreach (string val in input.ReadAsync(ct))
        {
            switch (val)
            {
                case var _ when val.StartsWith("BEGIN"):
                    var entityName = val.Replace("BEGIN", "").TrimStart().TrimEnd();
                    entityType = mapTypes[entityName];
                    await executor.ExecuteAsync(new TableRequest(), entityType, ct);
                    await executor.ExecuteAsync(new CreatePKRequest(), entityType, ct);
                    Console.WriteLine("Import {0}", entityType.Name);
                    break;
                case var _ when val.StartsWith("END"):
                    processed.Enqueue(entityType!);
                    break;
                default:
                    if (entityType is null)
                        throw new InvalidOperationException($"The type {val} is not a valid entity type");
                    object? model = JsonSerializer.Deserialize(val, entityType);
                    if (model is null)
                        throw new InvalidDataException($"Model of type {entityType} cannot be deserialized");
                    await executor.ExecuteAsync(new ImportRequest(), model, ct);
                    break;
            }
        }

        foreach (var item in processed)
        {
            Console.WriteLine("creating indexes for {0}", item.Name);
            await executor.ExecuteAsync(new CreateIndexRequest(), item, ct);
            Console.WriteLine("creating references for {0}", item.Name);
            await executor.ExecuteAsync(new CreateReferenceRequest(), item, ct);
        }
    }
}