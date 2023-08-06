using Fruitmarket;

namespace FruitmarketTests;

public class ProductTests : DatabaseTest
{
    public ProductTests()
    {
        _db.Database.EnsureCreated();
        var product = new Product("Keyboard", 200);
        _db.Products.Add(product);
        _db.SaveChanges();
    }
    
    [Fact]
    public void NameAndPriceSuccessTest()
    {
        Assert.Equal("Keyboard 200",_db.Products.First().NameAndPrice());
    }
}