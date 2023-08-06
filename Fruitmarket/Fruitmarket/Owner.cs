namespace Fruitmarket;

public class Owner : Person
{
    public string CompanyName { get; set; }
    public string CompanyType { get; set; }
    public Owner(Person person, string companyname, string companyType) : base(person.Firstname, person.Lastname, person.Address)
    {
        CompanyName = companyname;
        CompanyType = companyType;
    }
#pragma warning disable CS8618
    protected Owner()
    {
    }


  
}