using System.Globalization;
using CsvHelper.Configuration;
using Example02;
using Example02.Models;

const string filesDirectory = @"../../../../../files";

const string fooFile = $"{filesDirectory}/foo-export.csv";
const string barFile = $"{filesDirectory}/bar-export.csv";
const string foobarFile = $"{filesDirectory}/foobar-export.csv";

var cfg = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    HasHeaderRecord = true,
    IgnoreBlankLines = true
};

var csvFileWriter = new CsvFileWriter(cfg);

var fooRecords = new List<Foo>
{
    new()
    {
        Id = 1,
        FirstName = "Thalia",
        LastName = "Moreno",
        City = "Vienna"
    }
};

await csvFileWriter.WriteRecordsAsync(fooFile, fooRecords, CancellationToken.None);
Console.WriteLine($"Writing '{fooRecords.Count}' record(s) of type 'Foo'");

var barRecords = new List<Bar>
{
    new()
    {
        Id = 1,
        FirstName = "Thalia",
        LastName = "Moreno",
        City = "Vienna"
    }
};

await csvFileWriter.WriteRecordsAsync(barFile, barRecords, CancellationToken.None);
Console.WriteLine($"Writing '{barRecords.Count}' record(s) of type 'Bar'");

var foobarRecords = new List<FooBar>
{
    new()
    {
        Id = 1,
        FirstName = "Thalia",
        LastName = "Moreno",
        City = "Vienna"
    }
};

await csvFileWriter.WriteRecordsAsync<FooBar, FooBarMap>(foobarFile, foobarRecords, CancellationToken.None);
Console.WriteLine($"Writing '{foobarRecords.Count}' record(s) of type 'FooBar'");