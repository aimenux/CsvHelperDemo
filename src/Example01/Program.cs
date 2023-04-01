using System.Globalization;
using CsvHelper.Configuration;
using Example01;
using Example01.Models;

const string filesDirectory = @"../../../../../files";

const string fooFile = $"{filesDirectory}/foo.csv";
const string barFile = $"{filesDirectory}/bar.csv";
const string foobarFile = $"{filesDirectory}/foobar.csv";

var foobarConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    ShouldSkipRecord = args => int.TryParse(args.Row[0], out var index) && index % 2 != 0
};

await ReadFileAsync<Foo>(fooFile);
await ReadFileAsync<Bar>(barFile);
await ReadFileAsync<FooBar>(foobarFile, foobarConfig);

static async Task ReadFileAsync<T>(string file, CsvConfiguration config = null, CancellationToken cancellationToken = default)
{
    var csvFileReader = new CsvFileReader(config);
    var csvRecords = await csvFileReader.GetRecordsAsync<T>(file, cancellationToken);
    Console.WriteLine($"Found {csvRecords.Count} {typeof(T).Name.ToLower()} record(s)");
}


