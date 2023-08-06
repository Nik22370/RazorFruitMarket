using System.Diagnostics;
using Fruitmarket;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace FruitmarketTests;

[Collection("Sequential")]
public class DatabaseTest : IDisposable
{
    private readonly SqliteConnection _connection;
    protected readonly FruitMarketContext _db;

    public DatabaseTest()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();
        var opt = new DbContextOptionsBuilder()
            //.UseSqlite("Data Source=Fruit.db") 
            .UseSqlite(_connection)  // Keep connection open (only needed with SQLite in memory db)
            .UseLazyLoadingProxies()
            .LogTo(message => Debug.WriteLine(message), Microsoft.Extensions.Logging.LogLevel.Information)
            .EnableSensitiveDataLogging()
            .Options;

        _db = new FruitMarketContext(opt);
    }
    public void Dispose()
    {
        _db.Dispose();
        _connection.Dispose();
    }
}