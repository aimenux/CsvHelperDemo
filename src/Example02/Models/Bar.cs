using CsvHelper.Configuration.Attributes;

namespace Example02.Models;

public class Bar
{
    [Index(0)]
    public int Id { get; set; }

    [Index(1)]
    public string FirstName { get; set; }
    
    [Index(2)]
    public string LastName { get; set; }
    
    [Index(3)]
    public string City { get; set; }
}