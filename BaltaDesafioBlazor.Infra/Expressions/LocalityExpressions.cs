using BaltaDesafioBlazor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BaltaDesafioBlazor.Infra.Expressions;

public static class LocalityExpressions
{
    public static Expression<Func<Locality, bool>> IsLocalityEqual(string city, string state)
    {
        return i => i.City == city && i.State == state;
    }

    public static async Task<bool> IsIdAvailableAsync(
        this IQueryable<Locality> query,
        string id,
        CancellationToken cancellationToken = default)
    {
        return !await query.AnyAsync(i => i.Id == id, cancellationToken);
    }

    public static async Task<bool> IsLocalityAvailableAsync(
        this IQueryable<Locality> query,
        string city,
        string state,
        CancellationToken cancellationToken = default)
    {
        return !await query.AnyAsync(IsLocalityEqual(city, state), cancellationToken);
    }

    public static bool IsIdAvailable(
        this IQueryable<Locality> query,
        string id)
    {
        return !query.Any(i => i.Id == id);
    }

    public static bool IsLocalityAvailable(
        this IQueryable<Locality> query,
        string city,
        string state)
    {
        return !query.Any(IsLocalityEqual(city, state));
    }
}
