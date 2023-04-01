using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Example02;

public interface ICsvFileWriter
{
    Task WriteRecordsAsync<T>(string file, ICollection<T> records, CancellationToken cancellationToken);
    Task WriteRecordsAsync<T>(string file, ICollection<T> records, Type classMapType, CancellationToken cancellationToken);
}

public class CsvFileWriter : ICsvFileWriter
{
    private readonly CsvConfiguration _csvConfiguration;

    public CsvFileWriter(CsvConfiguration csvConfiguration = null)
    {
        _csvConfiguration = csvConfiguration ?? new CsvConfiguration(CultureInfo.InvariantCulture);
    }

    public async Task WriteRecordsAsync<T>(string file, ICollection<T> records, CancellationToken cancellationToken)
    {
        await using var writer = new StreamWriter(file);
        await using var csv = new CsvWriter(writer, _csvConfiguration);
        await csv.WriteRecordsAsync(records, cancellationToken);
    }

    public async Task WriteRecordsAsync<T>(string file, ICollection<T> records, Type classMapType, CancellationToken cancellationToken)
    {
        await using var writer = new StreamWriter(file);
        await using var csv = new CsvWriter(writer, _csvConfiguration);
        csv.Context.RegisterClassMap(classMapType);
        await csv.WriteRecordsAsync(records, cancellationToken);
    }
}