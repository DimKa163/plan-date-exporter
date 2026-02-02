using System.Reflection;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using PlanDate.Extractor.Data.MsSql.Requests;
using PlanDate.Extractor.Entities;
using DayOfWeek = PlanDate.Extractor.Entities.DayOfWeek;
using TimeZone = PlanDate.Extractor.Entities.TimeZone;

namespace PlanDate.Extractor.Data.MsSql;

public class Exporter(Executor executor, Output output)
{
    public async Task ExportAsync(CancellationToken token)
    {
        await Export<AskNonStandartCategory>(token);
        await Export<BPMFilial>(token);
        await Export<BpmReservationsStopLists>(token);
        await Export<Calendar>(token);
        await Export<DayInCalendar>(token);
        await Export<DayOff>(token);
        await Export<DayOfWeek>(token);
        await Export<DayType>(token);
        await Export<DeliveryType>(token);
        await Export<NrbCategorySKU>(token);
        await Export<NrbConfigurator>(token);
        await Export<NrbNormStatus>(token);
        await Export<NrbProductBalances>(token);
        await Export<NrbProductionRate>(token);
        await Export<NrbProductionSite>(token);
        await Export<NrbRelatedProduct>(token);
        await Export<NrbStandardPurchase>(token);
        await Export<NrbSubWarehouse>(token);
        await Export<NrbSubWarehouseCategories>(token);
        await Export<NrbTransportLeg>(token);
        await Export<NrbWarehouse>(token);
        await Export<NrbWorkSchedule>(token);
        await Export<Product>(token);
        await Export<ProductDeficit>(token);
        await Export<SmrShop>(token);
        await Export<SmrProductGroupFlag>(token);
        await Export<TimeZone>(token);
        await Export<WorkingTimeInterval>(token);
    }
    
    private async Task Export<TEntity>(CancellationToken cancellationToken) where TEntity : CreatioEntity
    {
        Type entityType = typeof(TEntity);
        string tableName = entityType.Name;
        Console.WriteLine($"Exporting {tableName}");
        string begin = $"BEGIN {tableName}";
        await output.WriteAsync(begin.AsMemory(), cancellationToken);
        await foreach (TEntity entity in executor.ReadAsync(new ReadRequest<TEntity>(), cancellationToken))
        {
            string json = JsonSerializer.Serialize(entity);
            await output.WriteAsync(json.AsMemory(), cancellationToken);
        }
        string end = $"END {tableName}";
        await output.WriteAsync(end.AsMemory(), cancellationToken);
    }
}
