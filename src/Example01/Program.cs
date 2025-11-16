using System.Globalization;
using CsvHelper.Configuration;
using Example01;
using Example01.Models;

const string filesDirectory = @"../../../../../files";

const string fooFile = $"{filesDirectory}/foo.csv";
const string barFile = $"{filesDirectory}/bar.csv";
const string foobarFile = $"{filesDirectory}/foobar.csv";

var cfg = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    HasHeaderRecord = true,
    IgnoreBlankLines = true
};

var csvFileReader = new CsvFileReader(cfg);

var fooRecords = await csvFileReader.GetRecordsAsync<Foo>(fooFile, CancellationToken.None);
Console.WriteLine($"Reading '{fooRecords.Count}' record(s) of type 'Foo'");

var barRecords = await csvFileReader.GetRecordsAsync<Bar>(barFile, CancellationToken.None);
Console.WriteLine($"Reading '{barRecords.Count}' record(s) of type 'Bar'");

var foobarRecords = await csvFileReader.GetRecordsAsync<FooBar, FooBarMap>(foobarFile, CancellationToken.None);
Console.WriteLine($"Reading '{foobarRecords.Count}' record(s) of type 'FooBar'");
