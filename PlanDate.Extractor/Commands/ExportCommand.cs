using System.CommandLine;
using System.Reflection;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using PlanDate.Extractor.Data.MsSql;
using PlanDate.Extractor.Data.MsSql.Requests;
using PlanDate.Extractor.Entities;
using DayOfWeek = PlanDate.Extractor.Entities.DayOfWeek;
using TimeZone = PlanDate.Extractor.Entities.TimeZone;

namespace PlanDate.Extractor.Commands;

public class ExportCommand : Command
{
    private readonly Option<string> _dbOption;
    private readonly Option<string> _outputOption;
    public ExportCommand(string name, string? description = null) : base(name, description)
    {
        _dbOption = new Option<string>("--db");
        Add(_dbOption);
        _outputOption = new Option<string>("--output");
        Add(_outputOption);
        SetAction(Execute);
    }

    protected virtual async Task Execute(ParseResult parseResult, CancellationToken cancellationToken)
    {
        if (parseResult.Errors.Any())
            throw new Exception();
        string? connectionString = parseResult.GetValue(_dbOption);
        
        string? outputPath = parseResult.GetValue(_outputOption);
        SqlConnection conn = new SqlConnection(connectionString);
        await conn.OpenAsync(cancellationToken);
        using Output output = new Output(outputPath!);
        Exporter exporter = new(new Reader(conn), output);
        await exporter.ExportAsync([
            Export<AskNonStandartCategory>,
            Export<BPMFilial>,
            Export<BpmReservationsStopLists>,
            Export<Calendar>,
            Export<DayInCalendar>,
            Export<DayOff>,
            Export<DayOfWeek>,
            Export<DayType>,
            Export<DeliveryType>,
            Export<NrbCategorySKU>,
            Export<NrbConfigurator>,
            Export<NrbNormStatus>,
            Export<NrbProductBalances>,
            Export<NrbProductionRate>,
            Export<NrbProductionSite>,
            Export<NrbRelatedProduct>,
            Export<NrbStandardPurchase>,
            Export<NrbSubWarehouse>,
            Export<NrbSubWarehouseCategories>,
            Export<NrbTransportLeg>,
            Export<NrbWarehouse>,
            Export<NrbWorkSchedule>,
            Export<Product>,
            Export<ProductDeficit>,
            Export<SmrShop>,
            Export<TimeZone>,
            Export<WorkingTimeInterval>
        ], cancellationToken);
    }

    private async Task Export<TEntity>(Reader reader, Output output, CancellationToken cancellationToken) where TEntity : CreatioEntity
    {
        Type entityType = typeof(TEntity);
        string tableName = entityType.Name;
        string begin = $"BEGIN {tableName}";
        await output.WriteAsync(begin.AsMemory(), cancellationToken);
        await foreach (TEntity entity in reader.ReadAsync(new ReadRequest<TEntity>(), cancellationToken))
        {
           string json = JsonSerializer.Serialize(entity);
           await output.WriteAsync(json.AsMemory(), cancellationToken);
        }
        string end = $"END {tableName}";
        await output.WriteAsync(end.AsMemory(), cancellationToken);
    }
}