using System.CommandLine;
using Microsoft.Data.SqlClient;
using PlanDate.Extractor.Data.MsSql;

namespace PlanDate.Extractor.Commands;

public class ImportCommand : Command
{
    private readonly Option<string> _dbOption;
    private readonly Option<string> _sourceOption;
    
    public ImportCommand(string name, string? description = null) : base(name, description)
    {
        _dbOption = new Option<string>("--db");
        Add(_dbOption);
        _sourceOption = new Option<string>("--source");
        Add(_sourceOption);
        SetAction(Execute);
    }

    protected virtual async Task Execute(ParseResult parseResult, CancellationToken cancellationToken)
    {
        if (parseResult.Errors.Any())
            throw new Exception();
        string? connectionString = parseResult.GetValue(_dbOption);
        
        string? sourcePath = parseResult.GetValue(_sourceOption);
        SqlConnection conn = new SqlConnection(connectionString);
        await conn.OpenAsync(cancellationToken);
        await using Input input = new Input(sourcePath!);
        Importer importer = new(new Executor(conn), input);
        await importer.ImportAsync(cancellationToken);
    }
}