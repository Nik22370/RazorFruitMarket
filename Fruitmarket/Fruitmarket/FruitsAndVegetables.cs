namespace Fruitmarket;

public class FruitsAndVegetables : Product
{
    public string Weight { get; set; }
    public bool IsFruit { get; set; }
#pragma warning disable CS8618
    protected FruitsAndVegetables()
    {
    }
#pragma warning restore CS8618
    public FruitsAndVegetables(Product product, string weight, bool isFruit) : base(product.Name, product.Price)
    {
        Weight = weight;
        IsFruit = isFruit;
    }

    public String AllInfos()
    {
        if (IsFruit)
        {
            return $"{base.Name} is a fruit an weights {Weight}";
        }
        else
        {
            return $"{base.Name} is a vegetable an weights {Weight}";
        }
    }
}