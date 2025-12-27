using System.IO.Compression;

namespace PlanDate.Extractor;

public class Output(string file) : IDisposable, IAsyncDisposable
{
    private readonly StreamWriter _fs = new(new GZipStream(new FileStream(file, FileMode.Create), CompressionMode.Compress));

    public async Task WriteAsync(ReadOnlyMemory<char> content, CancellationToken token)
    {
        await _fs.WriteLineAsync(content, token);
    }

    public void Dispose()
    {
        _fs.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _fs.DisposeAsync();
    }
}