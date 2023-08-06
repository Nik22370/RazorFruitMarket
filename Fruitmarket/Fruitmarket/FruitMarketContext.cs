using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Bogus;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Fruitmarket;

public class FruitMarketContext : DbContext
{
    public FruitMarketContext(DbContextOptions opt) : base(opt)
    {
    }

    //name der klasse  name in der db 
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<FruitsAndVegetables> FruitsAndVegetables => Set<FruitsAndVegetables>();
    public DbSet<Market> Markets => Set<Market>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Owner> Owners => Set<Owner>();
    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Product> Products => Set<Product>();


    //zusatzeinstellungen 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //value object 
        modelBuilder.Entity<Market>().OwnsOne(m => m.Address);
        modelBuilder.Entity<Person>().OwnsOne(p => p.Address);


        //Diskriminator definieren
        modelBuilder.Entity<Product>().HasDiscriminator(p => p.ProductType);
        modelBuilder.Entity<Person>().HasDiscriminator(p => p.PersonType);

        //Guid 
        modelBuilder.Entity<Product>().HasAlternateKey(p => p.Guid);
        modelBuilder.Entity<Product>().Property(p => p.Guid).ValueGeneratedOnAdd();
    }


    public void Seed()
    {
        var owner1 = new Owner(new Person("Hans", "Samuel",new Address("Hauptstraße", "1")), "Müller", "Abcd");
        var market1 = new Market("Edeka", new Address("Hauptstraße", "1"), owner1);
        var market2 = new Market("Rewe", new Address("Hauptstraße", "2"), owner1);
        var market3 = new Market("Aldi", new Address("Hauptstraße", "3"), owner1);
        var market4 = new Market("Lidl", new Address("Hauptstraße", "4"), owner1);

        Owners.Add(owner1);SaveChanges();
        Markets.AddRange(market1, market2, market3, market4);SaveChanges();


    }
    
    




}