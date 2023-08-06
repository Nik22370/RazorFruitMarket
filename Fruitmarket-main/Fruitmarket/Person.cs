namespace Fruitmarket;

public class Person
{
    public int Id { get; private set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public Address Address { get; set; }
    public string PersonType { get; private set; } = default!;


    public Person(string firstname, string lastname, Address address)
    {
        Firstname = firstname;
        Lastname = lastname;
        Address = address;
    }
#pragma warning disable CS8618
    protected Person()
    {
    }
#pragma warning restore CS8618

    public String AllInfos()
    {
        return $"{Firstname} {Lastname} {Address.Street} {Address.StreetNumber}";
    }
}