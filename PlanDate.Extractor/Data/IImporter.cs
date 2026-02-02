namespace PlanDate.Extractor.Data;

public interface IImporter
{
    Task ImportAsync(CancellationToken ct);
}