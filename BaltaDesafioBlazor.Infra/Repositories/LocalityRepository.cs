using BaltaDesafioBlazor.Domain.Entities;
using BaltaDesafioBlazor.Domain.Repositories;
using BaltaDesafioBlazor.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BaltaDesafioBlazor.Infra.Repositories;

internal class LocalityRepository(DataContext dataContext) : ILocalityRepository
{
    public async Task<bool> IsIdAvailableAsync(string id, CancellationToken cancellationToken = default)
    {
        return await dataContext.Localities.CountAsync(i => i.Id == id, cancellationToken) == 0;
    }

    public async Task<bool> IsLocalityAvailableAsync(string city, string state, CancellationToken cancellationToken = default)
    {
        return await dataContext.Localities.CountAsync(i => i.City == city && i.State == state, cancellationToken) == 0;
    }

    public async Task<Locality?> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            return await dataContext.Localities
                .SingleOrDefaultAsync(x => x.Id == id, cancellationToken)
                .ConfigureAwait(false);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<bool> CreateAsync(Locality locality, CancellationToken cancellationToken = default)
    {
        try
        {
            await dataContext.Localities
                .AddAsync(locality, cancellationToken)
                .ConfigureAwait(false);

            await dataContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(Locality locality, CancellationToken cancellationToken = default)
    {
        try
        {
            await dataContext.Localities
                .Where(i => i.Id == locality.Id)
                .ExecuteUpdateAsync(props => props
                .SetProperty(prop => prop.City, locality.City)
                .SetProperty(prop => prop.State, locality.State),
                cancellationToken)
                .ConfigureAwait(false);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteAndUpdateAsync(string oldId, Locality locality, CancellationToken cancellationToken = default)
    {
        await using var transaction = dataContext.Database.BeginTransaction();

        try
        {
            await dataContext.Localities
                .Where(i => i.Id == oldId)
                .ExecuteDeleteAsync(cancellationToken)
                .ConfigureAwait(false);

            var entity = new Locality(locality.Id, locality.City, locality.State);

            await dataContext.Localities
                .AddAsync(entity, cancellationToken)
                .ConfigureAwait(false);

            await dataContext.SaveChangesAsync(cancellationToken);

            await transaction
                .CommitAsync(cancellationToken)
                .ConfigureAwait(false);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            await dataContext.Localities
                .Where(i => i.Id == id)
                .ExecuteDeleteAsync(cancellationToken)
                .ConfigureAwait(false);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
