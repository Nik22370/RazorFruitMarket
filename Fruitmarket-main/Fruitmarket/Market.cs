using System.Data.Common;

namespace Fruitmarket;

public class Market
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public Address Address { get; set; }
    public virtual Owner Owner { get; set; }
    protected List<Product> _products = new List<Product>();
    public virtual IReadOnlyCollection<Product> Products => _products;
#pragma warning disable CS8618
    protected Market()
    {
    }
#pragma warning restore CS8618
    public Market(string name, Address address, Owner owner)
    {
        Name = name;
        Address = address;
        Owner = owner;
    }

    public void addProducts(Product product)
    {
        _products.Add(product);
    }

    public void addFruitOrVegetable(Product p, FruitsAndVegetables f)
    {
        _products.Add(new FruitsAndVegetables(p, f.Weight, f.IsFruit));
    }

    public void removeProducts(Product product)
    {
        _products.Remove(product);
    }

    public int countProducts()
    {
        return _products.Count;
    }
}