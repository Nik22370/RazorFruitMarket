//Erstellen und seeden der Datenbank

using System.Diagnostics;
using Fruitmarket;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;


var opt = new DbContextOptionsBuilder()
    .UseSqlite("Data Source=Fruit.db")
    .UseLazyLoadingProxies()
    .LogTo(message => Debug.WriteLine(message), Microsoft.Extensions.Logging.LogLevel.Information)
    .EnableSensitiveDataLogging()
    .Options;


using (var db = new FruitMarketContext(opt))
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
    db.Seed();
  
}



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<FruitMarketContext>(opt =>
{
    opt.UseSqlite("Data Source = Fruit.db");
});

//Middleware
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapRazorPages();
app.Run();
