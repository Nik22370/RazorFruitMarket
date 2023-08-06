namespace Fruitmarket;

public class Customer : Person
{
    
    public string Creditcard { get; set; }
#pragma warning disable CS8618
    protected Customer() { }
#pragma warning restore CS8618
    public Customer(Person person, string creditcard) : base(person.Firstname, person.Lastname, person.Address)
    {
        Creditcard = creditcard;
    }
    
}