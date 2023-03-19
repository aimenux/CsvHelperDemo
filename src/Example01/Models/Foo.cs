using CsvHelper.Configuration.Attributes;

namespace Example01.Models;

public class Foo
{
    [Name("IdHeader")]
    public int Id { get; set; }

    [Name("FirstNameHeader")]
    public string FirstName { get; set; }
    
    [Name("LastNameHeader")]
    public string LastName { get; set; }
    
    [Name("CityHeader")]
    public string City { get; set; }
}