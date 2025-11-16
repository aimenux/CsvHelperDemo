using CsvHelper.Configuration.Attributes;

namespace Example02.Models;

public sealed record Foo
{
    [Name("IdHeader")]
    public required int Id { get; init; }

    [Name("FirstNameHeader")]
    public required string FirstName { get; init; }
    
    [Name("LastNameHeader")]
    public required string LastName { get; init; }
    
    [Name("CityHeader")]
    public required string City { get; init; }
}