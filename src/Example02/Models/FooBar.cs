using CsvHelper.Configuration;

namespace Example02.Models;

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
        Map(m => m.Id).Index(0).Name("IdHeader");
        Map(m => m.FirstName).Index(1).Name("FirstNameHeader");
        Map(m => m.LastName).Index(2).Name("LastNameHeader");
        Map(m => m.City).Index(3).Name("CityHeader");
    }
}