using Fruitmarket;

namespace FruitmarketTests;

public class OrderTests : DatabaseTest
{
    public OrderTests()
    {
        _db.Database.EnsureCreated();
        var person = new Person("dean", "nikolic", new Address("Spengergasse", "20"));
        var customer = new Customer(person, "123");
        var product = new Product("Keyboard", 200);
        var order = new Order(customer);
        _db.Orders.Add(order);
        order.addProduct(product);
        _db.SaveChanges();
    }

    [Fact]
    public void AddProductSuccessTest()
    {
        Assert.Equal(1,_db.Orders.First().countProducts());
    }
    
    [Fact]
    public void RemoveProductSuccessTest()
    {
        var order = _db.Orders.First();
        var product = _db.Products.First();
        order.removeProducts(product);
        _db.SaveChanges();
        _db.ChangeTracker.Clear();
        Assert.Equal(0,_db.Orders.First().countProducts());
    }
    
    [Fact]
    public void TotalPriceSuccessTest()
    {
        Assert.Equal(200,_db.Orders.First().totalPrice());
    }
    [Fact]
    public void CountProductsSuccessTest()
    {
        Assert.Equal(1,_db.Orders.First().countProducts());
    }
}