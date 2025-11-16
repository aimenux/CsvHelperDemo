using CsvHelper.Configuration.Attributes;

namespace Example02.Models;

public sealed record Bar
{
    [Index(0)]
    public required int Id { get; init; }

    [Index(1)]
    public required string FirstName { get; init; }
    
    [Index(2)]
    public required string LastName { get; init; }
    
    [Index(3)]
    public required string City { get; init; }
}