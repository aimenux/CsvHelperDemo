using CsvHelper.Configuration;

namespace Example02.Models;

public sealed record FooBar
{
    public required int Id { get; init; }

    public required string FirstName { get; init; }
    
    public required string LastName { get; init; }
    
    public required string City { get; init; }
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