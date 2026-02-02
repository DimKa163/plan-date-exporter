using System.Data.Common;
using Microsoft.Data.SqlClient;
using Npgsql;
using PlanDate.Extractor.Data.MsSql;
using PlanDate.Extractor.Data.Npgsql;

namespace PlanDate.Extractor.Data;

public static class ImporterFactory
{
    public static DbConnection CreateConnection(DbDriver driver, string connectionString)
    {
        switch (driver)
        {
            case DbDriver.NPGSQL:
                return new NpgsqlConnection(connectionString);
            case DbDriver.MSSQL:
                return new SqlConnection(connectionString);
            default:
                throw new ArgumentOutOfRangeException(nameof(driver), driver, null);
        }
    }
    public static IImporter CreateImporter(DbDriver driver, Executor executor, Input input)
    {
        switch (driver)
        {
            case DbDriver.NPGSQL:
                return new NpgsqlImporter(executor, input);
            case DbDriver.MSSQL:
                return new MsSqlImporter(executor, input);
            default:
                throw new ArgumentOutOfRangeException(nameof(driver), driver, null);
        }
    }
}

public enum DbDriver
{
    MSSQL,
    NPGSQL,
}