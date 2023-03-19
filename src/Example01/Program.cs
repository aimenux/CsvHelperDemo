using Example01;
using Example01.Models;

const string filesDirectory = @"../../../../../files";

const string fooFile = $"{filesDirectory}/foo.csv";
const string barFile = $"{filesDirectory}/bar.csv";
const string foobarFile = $"{filesDirectory}/foobar.csv";

var csvFileReader = new CsvFileReader();

var fooRecords = await csvFileReader.GetRecordsAsync<Foo>(fooFile, CancellationToken.None);
var barRecords = await csvFileReader.GetRecordsAsync<Bar>(barFile, CancellationToken.None);
var foobarRecords = await csvFileReader.GetRecordsAsync<FooBar>(foobarFile, typeof(FooBarMap), CancellationToken.None);

Console.WriteLine($"Found {fooRecords.Count} foo record(s)");
Console.WriteLine($"Found {barRecords.Count} bar record(s)");
Console.WriteLine($"Found {foobarRecords.Count} foobar record(s)");




