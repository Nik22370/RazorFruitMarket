using System.Collections;

namespace Fruitmarket;

public class Product
{
    public List<FruitsAndVegetables> _fruitsandvegetables = new List<FruitsAndVegetables>();

    public List<Order> _order = new List<Order>();
    
    public int Id { get; private set; }
    public Guid Guid { get; private set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    
    public int MarketId { get; set; }
    
    //Discriminator
    public string ProductType { get; private set; } = default!;


    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
        
        Guid = Guid.NewGuid();
    }
    
    public Product(string name, decimal price,int marketId)
    {
        Name = name;
        Price = price;
        MarketId = marketId;
        
        Guid = Guid.NewGuid();
    }
    
#pragma warning disable CS8618
    protected Product()
    {
        
    }
#pragma warning restore CS8618
    public string NameAndPrice()
    {
        return Name + " " + Price;
    }
}