namespace FruitmarketTests;

public class FruitMarketContextTests : DatabaseTest
{
    [Fact]
    public void CreateDatabaseTest()
    {
        _db.Database.EnsureCreated();
    }



    public void SeedSuccessTest()
    {
        _db.Database.EnsureCreated();
        //_db.Seed();
        
        _db.ChangeTracker.Clear();
        Assert.True(_db.Products.ToList().Count > 0);
        Assert.True(_db.Orders.ToList().Count > 0);
        Assert.True(_db.Markets.ToList().Count > 0);
        Assert.True(_db.Customers.ToList().Count > 0);
        Assert.True(_db.Products.ToList().Count > 0);
        Assert.True(_db.FruitsAndVegetables.ToList().Count > 0);
        Assert.True(_db.Addresses.ToList().Count > 0);
        Assert.True(_db.Owners.ToList().Count > 0);
       
    }
    
    
}