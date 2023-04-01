using Bogus;
using Example02.Models;
using FluentAssertions;

namespace Example02.Tests;

public class CsvFileWriterTests
{
    private const string FilesDirectory = @"../../../../../files";
    
    [Theory]
    [InlineData($"{FilesDirectory}/foo-export.csv")]
    public async Task Should_Write_Records_For_Foo_Records(string file)
    {
        // arrange
        const int maxRecords = 10;
        var faker = new Faker<Foo>()
            .RuleFor(x => x.Id, f => f.UniqueIndex)
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .RuleFor(x => x.City, f => f.Address.City());	
        var records = faker.GenerateBetween(maxRecords, maxRecords);
        
        var writer = new CsvFileWriter();

        // act
        await writer.WriteRecordsAsync(file, records, CancellationToken.None);

        // assert
        File.Exists(file).Should().BeTrue();
        var lines = await File.ReadAllLinesAsync(file);
        lines.Should().NotBeNullOrEmpty().And.HaveCount(maxRecords + 1);
        lines.First().Should().Be("IdHeader,FirstNameHeader,LastNameHeader,CityHeader");
    }
    
    [Theory]
    [InlineData($"{FilesDirectory}/bar-export.csv")]
    public async Task Should_Write_Records_For_Bar_Records(string file)
    {
        // arrange
        const int maxRecords = 10;
        var faker = new Faker<Bar>()
            .RuleFor(x => x.Id, f => f.UniqueIndex)
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .RuleFor(x => x.City, f => f.Address.City());	
        var records = faker.GenerateBetween(maxRecords, maxRecords);
        
        var writer = new CsvFileWriter();

        // act
        await writer.WriteRecordsAsync(file, records, CancellationToken.None);

        // assert
        File.Exists(file).Should().BeTrue();
        var lines = await File.ReadAllLinesAsync(file);
        lines.Should().NotBeNullOrEmpty().And.HaveCount(maxRecords + 1);
        lines.First().Should().Be("Id,FirstName,LastName,City");
    }
    
    [Theory]
    [InlineData($"{FilesDirectory}/foobar-export.csv")]
    public async Task Should_Write_Records_For_FooBar_Records(string file)
    {
        // arrange
        const int maxRecords = 10;
        var faker = new Faker<FooBar>()
            .RuleFor(x => x.Id, f => f.UniqueIndex)
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .RuleFor(x => x.City, f => f.Address.City());	
        var records = faker.GenerateBetween(maxRecords, maxRecords);
        
        var writer = new CsvFileWriter();

        // act
        await writer.WriteRecordsAsync(file, records, typeof(FooBarMap), CancellationToken.None);

        // assert
        File.Exists(file).Should().BeTrue();
        var lines = await File.ReadAllLinesAsync(file);
        lines.Should().NotBeNullOrEmpty().And.HaveCount(maxRecords + 1);
        lines.First().Should().Be("IdHeader,FirstNameHeader,LastNameHeader,CityHeader");
    }
}