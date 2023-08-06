using Microsoft.EntityFrameworkCore;

namespace Fruitmarket;

public class FruitMarketContext : DbContext
{
    public FruitMarketContext(DbContextOptions opt) : base(opt) { }
    
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<FruitsAndVegetables> FruitsAndVegetables => Set<FruitsAndVegetables>();
    public DbSet<Market> Markets => Set<Market>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Owner> Owners => Set<Owner>();
    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Product> Products => Set<Product>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Market>().OwnsOne(m => m.Address);
        modelBuilder.Entity<Person>().OwnsOne(p => p.Address);
      

        modelBuilder.Entity<Product>().HasDiscriminator(p => p.ProductType);
        modelBuilder.Entity<Person>().HasDiscriminator(p => p.PersonType);
    
        modelBuilder.Entity<Product>().HasAlternateKey(p => p.Guid);

    }







    

}