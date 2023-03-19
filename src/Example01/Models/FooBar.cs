using CsvHelper.Configuration;

namespace Example01.Models;

public class FooBar
{
    public int Id { get; set; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string City { get; set; }
}

public class FooBarMap : ClassMap<FooBar>
{
    public FooBarMap()
    {
        Map(m => m.Id).Name("IdHeader");
        Map(m => m.FirstName).Name("FirstNameHeader");
        Map(m => m.LastName).Name("LastNameHeader");
        Map(m => m.City).Name("CityHeader");
    }
}