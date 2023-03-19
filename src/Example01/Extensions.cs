namespace Example01;

public static class Extensions
{
    public static async Task<List<T>> ToListAsync<T>(this IAsyncEnumerable<T> items, CancellationToken cancellationToken)
    {
        var results = new List<T>();
        
        await foreach (var item in items.WithCancellation(cancellationToken))
        {
            results.Add(item);
        }

        return results;
    }
}