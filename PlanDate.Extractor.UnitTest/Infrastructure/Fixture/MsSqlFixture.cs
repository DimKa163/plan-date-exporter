using Microsoft.Data.SqlClient;
using Testcontainers.MsSql;

namespace PlanDate.Extractor.UnitTest.Infrastructure.Fixture;

public class MsSqlFixture : IAsyncLifetime
{
    public MsSqlContainer Container { get; private set; } = null!;
    public string ConnectionString { get; private set; } = null!;
    public async Task InitializeAsync()
    {
        Container = new MsSqlBuilder()
            .WithPassword("123qweASD!")
            .Build();

        await Container.StartAsync();
        ConnectionString = Container.GetConnectionString(); // обычно Database=master
        await using (var conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();

            await using var cmd = new SqlCommand("""
                                                 IF DB_ID('TestDb') IS NULL
                                                     CREATE DATABASE TestDb;
                                                 """, conn);

            await cmd.ExecuteNonQueryAsync();
        }
        
        await ApplySqlAsync(ConnectionString, DbSchema.CreateTables);
        await ApplySqlAsync(ConnectionString, DbSchema.SeedData);
    }

    public async Task DisposeAsync()
    {
        await Container.DisposeAsync();
    }
    
    private static async Task ApplySqlAsync(string cs, string sql)
    {
        await using var conn = new SqlConnection(cs);
        await conn.OpenAsync();

        await using var cmd = new SqlCommand(sql, conn);
        await cmd.ExecuteNonQueryAsync();
    }
}