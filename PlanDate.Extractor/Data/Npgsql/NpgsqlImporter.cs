using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using PlanDate.Extractor.Data.Npgsql.Requests;
using PlanDate.Extractor.Entities;

namespace PlanDate.Extractor.Data.Npgsql;

public class NpgsqlImporter(Executor executor, Input input) : IImporter
{
    public async Task ImportAsync(CancellationToken ct)
    {
        var assembly = Assembly.GetEntryAssembly();
        if (assembly is null)
            throw new InvalidOperationException("The assembly should not be null");
        var mapTypes = assembly.GetTypes().Where(x => !x.IsAbstract && x.BaseType == typeof(CreatioEntity)).ToDictionary(x => x.Name);
        Queue<Type> processed = new Queue<Type>();
        Type? entityType = null;
        int size = 10000;
        List<object> list = new(size);
        long start = 0;
        int count = 0;
        await foreach (string val in input.ReadAsync(ct))
        {
            switch (val)
            {
                case var _ when val.StartsWith("BEGIN"):
                    var entityName = val.Replace("BEGIN", "").TrimStart().TrimEnd();
                    entityType = mapTypes[entityName];
                    // await executor.ExecuteAsync(new TableRequest(), entityType, ct);
                    
                    Console.WriteLine("{0}: Import {1}", DateTime.Now, entityType.Name);
                    start = Stopwatch.GetTimestamp();
                    break;
                case var _ when val.StartsWith("END"):
                    Console.WriteLine($"{DateTime.Now}: Importing {list.Count} to {entityType.Name}");
                    // await executor.ExecuteAsync(new MultipleImportRequest(), list, ct);
                    var duration = Stopwatch.GetElapsedTime(start);
                    Console.WriteLine("{0}: Imported {1}({2}) in {3}", DateTime.Now, entityType.Name, list.Count, duration);
                    // await executor.ExecuteAsync(new CreatePKRequest(), entityType, ct);
                    processed.Enqueue(entityType!);
                    list.Clear();
                    break;
                default:
                    if (entityType is null)
                        throw new InvalidOperationException($"The type {val} is not a valid entity type");
                    object? model = JsonSerializer.Deserialize(val, entityType);
                    if (model is null)
                        throw new InvalidDataException($"Model of type {entityType} cannot be deserialized");
                    list.Add(model);
                    if (list.Count == size)
                    {
                        count += list.Count;
                        var d = Stopwatch.GetElapsedTime(start);
                        Console.WriteLine($"{DateTime.Now}: Importing {count} to {entityType.Name} in {d}");
                        await executor.ExecuteAsync(new MultipleImportRequest(), list, ct);
                        list.Clear();
                    }
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