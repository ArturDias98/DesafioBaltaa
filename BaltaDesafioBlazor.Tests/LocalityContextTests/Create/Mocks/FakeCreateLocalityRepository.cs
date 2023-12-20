using BaltaDesafioBlazor.Domain.Entities;
using BaltaDesafioBlazor.Domain.Repositories;

namespace BaltaDesafioBlazor.Tests.LocalityContextTests.Create.Mocks;

internal class FakeCreateLocalityRepository : ILocalityRepository
{
    public Task<bool> CreateAsync(Locality locality, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAndUpdateAsync(string oldId, Locality locality, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public Task<bool> IsLocalityAvailableAsync(string city, string state, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Locality locality, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
