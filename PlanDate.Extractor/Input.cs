using System.IO.Compression;
using System.Runtime.CompilerServices;

namespace PlanDate.Extractor;

public class Input(string file) : IDisposable, IAsyncDisposable
{
    private readonly StreamReader _fs = new(new GZipStream(new FileStream(file, FileMode.Open), CompressionMode.Decompress));

    public async IAsyncEnumerable<string> ReadAsync([EnumeratorCancellation] CancellationToken token)
    {
        string? line = await _fs.ReadLineAsync(token);
        while (!string.IsNullOrWhiteSpace(line))
        {
            yield return line;
            line = await _fs.ReadLineAsync(token);
        }
    }

    public void Dispose()
    {
        _fs.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        _fs.Dispose();   
    }
}