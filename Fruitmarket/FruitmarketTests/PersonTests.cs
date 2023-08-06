using Fruitmarket;

namespace FruitmarketTests;

public class PersonTests : DatabaseTest
{
    public PersonTests()
    {
        _db.Database.EnsureCreated();
        var person = new Person("dean", "nikolic", new Address("Spengergasse", "20"));
        _db.Persons.Add(person);
        _db.SaveChanges();
    }

    [Fact]
    public void AllInfosSuccessTest()
    {
        Assert.Equal("dean nikolic Spengergasse 20",_db.Persons.First().AllInfos());
    }
}