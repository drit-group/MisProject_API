namespace MisProject.DataLayer.Tests;

public static class MockData
{
    private static readonly string MySqlConnectionString =
        "Server=127.0.0.1;Database=mis_Test;Uid=root;Pwd=Password;";

    private static DbContextOptionsBuilder<MisDbContext> MockDbContextOptionsBuilder() => new DbContextOptionsBuilder<MisDbContext>()
        .UseMySql(connectionString: MySqlConnectionString,
            ServerVersion.AutoDetect(MySqlConnectionString));

    public static MisDbContext DbContext = new(MockDbContextOptionsBuilder().Options);
}