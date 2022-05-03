using EventIntelligenceAPI.Application.Interfaces;
using EventIntelligenceAPI.Application.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace EventIntelligenceAPI.Application.Extensions;

public static class QueryablePaginateExtension
{
    public static async Task<IPaginate<T>> ToPaginateAsync<T>(this IQueryable<T> source, int index, int size, int from = 0, CancellationToken cancellationToken = default)
    {
        if (from > index) throw new ArgumentException($"From: {from} > Index: {index}, must From <= Index");

        var count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
        var items = await source.Skip((index - from) * size)
            .Take(size).ToListAsync(cancellationToken).ConfigureAwait(false);

        return new Paginate<T>
        {
            Count = count,
            Items = items,
            Pages = (int)Math.Ceiling(count / (double)size)
        };
    }
}