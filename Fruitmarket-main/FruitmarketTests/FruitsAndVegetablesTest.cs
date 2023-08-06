using Fruitmarket;

namespace FruitmarketTests;

public class FruitsAndVegetablesTest : DatabaseTest
{
    public FruitsAndVegetablesTest()
    {
        _db.Database.EnsureCreated();
        var product = new Product("Ananas", 2);
        var fAv = new FruitsAndVegetables(product, "0.5 Kg", true);
        _db.FruitsAndVegetables.Add(fAv);
        _db.SaveChanges();
    }

    [Fact]
    public void AllInfosSuccessTest()
    {
        Assert.Equal("0.5 Kg",_db.FruitsAndVegetables.First().Weight);
    }
}