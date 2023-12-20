using BaltaDesafioBlazor.Domain.Entities;
using BaltaDesafioBlazor.Domain.Repositories;
using BaltaDesafioBlazor.Infra.Expressions;

namespace BaltaDesafioBlazor.Tests.LocalityContextTests.Update.Mocks;

internal class FakeUpdateLocalityRepository : ILocalityRepository
{
    public Task<bool> CreateAsync(Locality locality, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAndUpdateAsync(string oldId, Locality locality, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Locality?> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsIdAvailableAsync(string id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(
            FakeDataContext.Context
            .AsQueryable()
            .IsIdAvailable(id));
    }

    public Task<bool> IsLocalityAvailableAsync(string city, string state, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(
            FakeDataContext.Context
            .AsQueryable()
            .IsLocalityAvailable(city, state));
    }

    public Task<bool> UpdateAsync(Locality locality, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true);
    }
}
