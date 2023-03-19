using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Example01;

public interface ICsvFileReader
{
    Task<ICollection<T>> GetRecordsAsync<T>(string file, CancellationToken cancellationToken);
    Task<ICollection<T>> GetRecordsAsync<T>(string file, Type classMapType, CancellationToken cancellationToken);
}

public class CsvFileReader : ICsvFileReader
{
    public async Task<ICollection<T>> GetRecordsAsync<T>(string file, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(file);
        var config = new CsvConfiguration(CultureInfo.InvariantCulture);
        using var csv = new CsvReader(reader, config);
        var records = csv.GetRecordsAsync<T>(cancellationToken);
        return await records.ToListAsync(cancellationToken);
    }

    public async Task<ICollection<T>> GetRecordsAsync<T>(string file, Type classMapType, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(file);
        var config = new CsvConfiguration(CultureInfo.InvariantCulture);
        using var csv = new CsvReader(reader, config);
        csv.Context.RegisterClassMap(classMapType);
        var records = csv.GetRecordsAsync<T>(cancellationToken);
        return await records.ToListAsync(cancellationToken);
    }
}