namespace PlanDate.Extractor.UnitTest.Infrastructure.Fixture;

public static  class DbSchema
{
    public const string CreateTables = """
                                       IF OBJECT_ID('dbo.Contact', 'U') IS NULL
                                       BEGIN
                                           CREATE TABLE dbo.Contact
                                           (
                                               Id   UNIQUEIDENTIFIER CONSTRAINT PK_Contacts PRIMARY KEY,
                                               Name NVARCHAR(50) NOT NULL
                                           );
                                       END
                                       """;
    
    public const string SeedData = """
                                   IF NOT EXISTS (SELECT 1 FROM dbo.Contact)
                                   BEGIN
                                       INSERT INTO dbo.Contact (Id, Name) VALUES (NEWID(), N'Alice'), (NEWID(), N'Bob');
                                   END
                                   """;
}