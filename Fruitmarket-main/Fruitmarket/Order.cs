namespace Fruitmarket;

public class Order
{
    public int Id { get; private set; }
    public DateTime Date { get; set; }
    public virtual Customer Customer { get; set; }
    protected List<Product> _products = new List<Product>();
    public virtual IReadOnlyCollection<Product> Products => _products;

#pragma warn ing disable CS8618
    protected Order() { }
#pragma warning restore CS8618
    public Order(Customer customer)
    {
        Customer = customer;
        Date = DateTime.Today;
    }

    public decimal totalPrice()
    {
        return _products.Sum(p => p.Price);
    }

    public void addProduct(Product product)
    {
        _products.Add(product);
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