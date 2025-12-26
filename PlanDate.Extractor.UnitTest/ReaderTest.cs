using Dapper;
using Microsoft.Data.SqlClient;
using PlanDate.Extractor.Data;
using PlanDate.Extractor.Data.MsSql;
using PlanDate.Extractor.Data.MsSql.Requests;
using PlanDate.Extractor.Entities;
using PlanDate.Extractor.UnitTest.Infrastructure.Fixture;

namespace PlanDate.Extractor.UnitTest;
[Collection("mssql")]
public class ReaderTest
{
    private readonly MsSqlFixture _db;

    public ReaderTest(MsSqlFixture db)
    {
        _db = db;
    }
    
    [Fact]
    public async Task ReadContactShouldBeSuccess()
    {
        SqlConnection conn = new SqlConnection(_db.ConnectionString);
        await conn.OpenAsync();
        Reader reader = new Reader(conn);
        var list = new List<Contact>();

        await foreach (var c in reader.ReadAsync(new ReadRequest<Contact>(), CancellationToken.None))
        {
            list.Add(c);
        }
        Assert.Equal(2, list.Count);
    }
}
[MsSqlTable("Contact")]
public record Contact : CreatioEntity
{
    [MsSqlColumn("Name")]
    public string Name { get; set; }
}

public class ContactReaderRequest : IEntityReaderRequest<Contact>
{
    public IAsyncEnumerable<Contact> ReadAsync(SqlConnection connection, CancellationToken token = default)
    {
        return connection.QueryUnbufferedAsync<Contact>("SELECT Id, Name FROM [Contact]");
    }
}