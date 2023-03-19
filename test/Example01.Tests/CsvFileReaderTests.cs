using Example01.Models;
using FluentAssertions;

namespace Example01.Tests;

public class CsvFileReaderTests
{
    private const string FilesDirectory = @"../../../../../files";
    
    [Theory]
    [InlineData($"{FilesDirectory}/foo.csv")]
    public async Task Should_Get_Records_For_Foo_Files(string file)
    {
        // arrange
        var reader = new CsvFileReader();

        // act
        var records = await reader.GetRecordsAsync<Foo>(file, CancellationToken.None);

        // assert
        records.Should().NotBeNullOrEmpty().And.HaveCount(4);
    }
    
    [Theory]
    [InlineData($"{FilesDirectory}/bar.csv")]
    public async Task Should_Get_Records_For_Bar_Files(string file)
    {
        // arrange
        var reader = new CsvFileReader();

        // act
        var records = await reader.GetRecordsAsync<Bar>(file, CancellationToken.None);

        // assert
        records.Should().NotBeNullOrEmpty().And.HaveCount(4);
    }
    
    [Theory]
    [InlineData($"{FilesDirectory}/foobar.csv")]
    public async Task Should_Get_Records_For_FooBar_Files(string file)
    {
        // arrange
        var reader = new CsvFileReader();

        // act
        var records = await reader.GetRecordsAsync<FooBar>(file, typeof(FooBarMap), CancellationToken.None);

        // assert
        records.Should().NotBeNullOrEmpty().And.HaveCount(4);
    }
}