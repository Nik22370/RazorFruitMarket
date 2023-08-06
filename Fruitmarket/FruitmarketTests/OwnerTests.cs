using Fruitmarket;

namespace FruitmarketTests;

public class OwnerTests : DatabaseTest
{
    public OwnerTests()
    {
        _db.Database.EnsureCreated();
        var person = new Person("dean", "nikolic", new Address("Spengergasse", "20"));
        var owner = new Owner(person, "software bude", "GmbH");
        _db.Owners.Add(owner);
        _db.SaveChanges();
    }

    [Fact]
    public void AllInfosSuccessTest()
    {
        Assert.True(_db.Owners.First().AllInfos()=="software bude GmbH");
    }
}