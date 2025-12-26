using System.CommandLine;

namespace PlanDate.Extractor.Commands;

public class VersionCommand : Command
{
    public VersionCommand(string name, string? description = null) : base(name, description)
    {
        var option = new Option<string>("--user");
        Add(option);
        SetAction(p =>
        {
            Console.WriteLine(p.GetValue(option));
        });
    }
}