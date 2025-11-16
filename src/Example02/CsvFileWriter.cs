using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Example02;

public interface ICsvFileWriter
{
    Task WriteRecordsAsync<T>(string file, ICollection<T> records, CancellationToken cancellationToken);
    
    Task WriteRecordsAsync<T>(string file, ICollection<T> records, Type classMapType, CancellationToken cancellationToken);
    
    Task WriteRecordsAsync<TU, TV>(string file, ICollection<TU> records, CancellationToken cancellationToken) where TV : ClassMap<TU>;
}

public class CsvFileWriter : ICsvFileWriter
{
    private readonly CsvConfiguration _csvConfiguration;

    public CsvFileWriter(CsvConfiguration? csvConfiguration = null)
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

    public async Task WriteRecordsAsync<TU, TV>(string file, ICollection<TU> records, CancellationToken cancellationToken) where TV : ClassMap<TU>
    {
        await using var writer = new StreamWriter(file);
        await using var csv = new CsvWriter(writer, _csvConfiguration);
        csv.Context.RegisterClassMap<TV>();
        await csv.WriteRecordsAsync(records, cancellationToken);
    }
}