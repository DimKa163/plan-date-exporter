// See https://aka.ms/new-console-template for more information

using System.CommandLine;
using PlanDate.Extractor.Commands;

class Program
{
    static Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("exporter");
        rootCommand.Add(new VersionCommand("version"));
        rootCommand.Add(new ExportCommand("export"));
        rootCommand.Add(new ImportCommand("import"));
        rootCommand.SetAction(async (p, ct) =>
        {
            Console.WriteLine("Hello {0}, Its plan date data extractor", 0);
        });

       return rootCommand.Parse(args).InvokeAsync();
    }
}
