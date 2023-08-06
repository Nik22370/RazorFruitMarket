using Fruitmarket;

namespace FruitmarketTests;

public class MarketTests : DatabaseTest
{
    public MarketTests()
    {
        _db.Database.EnsureCreated();
        var person = new Person("dean", "nikolic", new Address("Spengergasse", "20"));
        var owner = new Owner(person, "software bude", "GmbH");
        var market = new Market("super-software",new Address("maxweg", "12"), owner);
        var product = new Product("Keyboard", 200);
        market.addProducts(product);
        _db.Markets.Add(market);
        _db.SaveChanges();
    }

    [Fact]
    public void AddProductSuccessTest()
    {
        Assert.True(_db.Markets.First().countProducts() == 1);
    }
    [Fact]
    public void CountProductsSuccessTest()
    {
        Assert.True(_db.Markets.First().countProducts() == 1);
    }
    
    [Fact]
    public void RemoveProductSuccessTest()
    {
        var market = _db.Markets.First();
        var product = _db.Products.First();
        
        market.removeProducts(product);
        
        _db.SaveChanges();
        
        _db.ChangeTracker.Clear();
        
        Assert.True(_db.Markets.First().countProducts() == 0);
    }
    
    
}