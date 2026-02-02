using System.CommandLine;
using Microsoft.Data.SqlClient;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.MsSql;

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
        await using Output output = new Output(outputPath!);
        Exporter exporter = new(new Executor(conn), output);
        await exporter.ExportAsync(cancellationToken);
    }
}