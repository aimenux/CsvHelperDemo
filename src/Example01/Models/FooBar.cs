using CsvHelper.Configuration;

namespace Example01.Models;

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
        Map(m => m.Id).Name("IdHeader");
        Map(m => m.FirstName).Name("FirstNameHeader");
        Map(m => m.LastName).Name("LastNameHeader");
        Map(m => m.City).Name("CityHeader");
    }
}