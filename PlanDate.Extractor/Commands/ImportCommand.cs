using System.CommandLine;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.MsSql;

namespace PlanDate.Extractor.Commands;

public class ImportCommand : Command
{
    private readonly Option<string> _dbOption;
    private readonly Option<string> _sourceOption;
    private readonly Option<DbDriver> _driverOption;
    
    public ImportCommand(string name, string? description = null) : base(name, description)
    {
        _dbOption = new Option<string>("--db");
        Add(_dbOption);
        _sourceOption = new Option<string>("--source");
        Add(_sourceOption);
        _driverOption = new Option<DbDriver>("--driver");
        Add(_driverOption);
        SetAction(Execute);
    }

    protected virtual async Task Execute(ParseResult parseResult, CancellationToken cancellationToken)
    {
        if (parseResult.Errors.Any())
            throw new Exception();
        string? connectionString = parseResult.GetValue(_dbOption);
        
        string? sourcePath = parseResult.GetValue(_sourceOption);
        
        DbDriver? driver = parseResult.GetValue(_driverOption);
        
        DbConnection conn = ImporterFactory.CreateConnection(driver.Value, connectionString! );
        await conn.OpenAsync(cancellationToken);
        await using Input input = new Input(sourcePath!);
        IImporter importer = ImporterFactory.CreateImporter(driver.Value, new Executor(conn), input);
        await importer.ImportAsync(cancellationToken);
    }
}