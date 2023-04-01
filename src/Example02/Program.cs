using Example02;
using Example02.Models;

const string filesDirectory = @"../../../../../files";

await WriteFooFileAsync();
await WriteBarFileAsync();
await WriteFooBarFileAsync();

static async Task WriteFooFileAsync(CancellationToken cancellationToken = default)
{
    var records = new List<Foo>
    {
        new()
        {
            Id = 1,
            FirstName = "Thalia",
            LastName = "Moreno",
            City = "Vienna"
        }
    };
    
    const string fooFile = $"{filesDirectory}/foo-export.csv";
    var csvFileWriter = new CsvFileWriter();
    await csvFileWriter.WriteRecordsAsync(fooFile, records, cancellationToken);
}

static async Task WriteBarFileAsync(CancellationToken cancellationToken = default)
{
    var records = new List<Bar>
    {
        new()
        {
            Id = 1,
            FirstName = "Thalia",
            LastName = "Moreno",
            City = "Vienna"
        }
    };
    
    const string barFile = $"{filesDirectory}/bar-export.csv";
    var csvFileWriter = new CsvFileWriter();
    await csvFileWriter.WriteRecordsAsync(barFile, records, cancellationToken);
}

static async Task WriteFooBarFileAsync(CancellationToken cancellationToken = default)
{
    var records = new List<FooBar>
    {
        new()
        {
            Id = 1,
            FirstName = "Thalia",
            LastName = "Moreno",
            City = "Vienna"
        }
    };
    
    const string foobarFile = $"{filesDirectory}/foobar-export.csv";
    var classMapType = typeof(FooBarMap);
    var csvFileWriter = new CsvFileWriter();
    await csvFileWriter.WriteRecordsAsync(foobarFile, records, classMapType, cancellationToken);
}