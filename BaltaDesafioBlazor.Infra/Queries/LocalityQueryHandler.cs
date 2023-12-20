using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Queries;
using BaltaDesafioBlazor.Infra.Data;
using BaltaDesafioBlazor.Shared.Models.Locality;
using BaltaDesafioBlazor.Shared.Models.Result;
using Microsoft.EntityFrameworkCore;

namespace BaltaDesafioBlazor.Infra.Queries;

internal class LocalityQueryHandler(IDbContextFactory<DataContext> contextFactory) : ILocalityQueryHandler
{
    public async Task<QueryPaginationResultModel<List<LocalityModel>>> GetLocalitiesAsync(int page = 0, int pageSize = 50, string state = "", string city = "", CancellationToken cancellationToken = default)
    {
        try
        {
            await using var context = contextFactory.CreateDbContext();
            var query = context.Localities
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(state))
            {
                query = query.Where(i => i.State.ToLower().Contains(state.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(city))
            {
                query = query.Where(i => i.City.ToLower().Contains(city.ToLower()));
            }

            query = query
                .OrderBy(i => i.State)
                .ThenBy(i => i.City);

            var total = await query
                .CountAsync(cancellationToken)
                .ConfigureAwait(false);

            var result = await query
                .Select(i => new LocalityModel
                {
                    Id = i.Id,
                    City = i.City,
                    State = i.State,
                })
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return new(true, result, total);
        }
        catch (Exception)
        {
            return new QueryPaginationResultModel<List<LocalityModel>>(false, [], 0);
        }
    }

    public async Task<QueryResultModel<LocalityModel>> GetLocalityAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var context = contextFactory.CreateDbContext();
            var result = await context.Localities
                .AsNoTracking()
                .Where(i => i.Id == id)
                .Select(i => new LocalityModel
                {
                    Id = i.Id,
                    City = i.City,
                    State = i.State
                })
                .SingleOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            return new(true, result ?? new());
        }
        catch (Exception)
        {
            return new(false, new());
        }
    }
}
