// See https://aka.ms/new-console-template for more information

using System.CommandLine;
using PlanDate.Extractor.Commands;

class Program
{
    static Task<int> Main(string[] args)
    {
        var option = new Option<string>("--user");
        var rootCommand = new RootCommand("Extractor")
        {
            option
        };
        rootCommand.Add(new VersionCommand("version"));
        rootCommand.SetAction(async (p, ct) =>
        {
            var user = p.GetValue(option);
            Console.WriteLine("Hello {0}, Its plan date data extractor", user);
        });

       return rootCommand.Parse(args).InvokeAsync();
    }
}
