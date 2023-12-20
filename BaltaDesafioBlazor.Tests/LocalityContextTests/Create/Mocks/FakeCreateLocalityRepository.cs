using BaltaDesafioBlazor.Domain.Entities;
using BaltaDesafioBlazor.Domain.Repositories;
using BaltaDesafioBlazor.Infra.Expressions;

namespace BaltaDesafioBlazor.Tests.LocalityContextTests.Create.Mocks;

internal class FakeCreateLocalityRepository : ILocalityRepository
{
    private readonly List<Locality> _localities =
    [
        new Locality("1234567", "Random City 1", "R1"),
        new Locality("1593578", "Random City 2", "R2"),
        new Locality("7539516", "Random City 3", "R3"),
    ];

    public Task<bool> CreateAsync(Locality locality, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAndUpdateAsync(string oldId, Locality locality, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true);
    }

    public Task<Locality?> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_localities.Find(i => i.Id == id));
    }

    public Task<bool> IsIdAvailableAsync(string id, CancellationToken cancellationToken = default)
    {
        return _localities
            .AsQueryable()
            .IsIdAvailableAsync(id, cancellationToken);
    }

    public Task<bool> IsLocalityAvailableAsync(string city, string state, CancellationToken cancellationToken = default)
    {
        return _localities
            .AsQueryable()
            .IsLocalityAvailableAsync(city, state, cancellationToken);
    }

    public Task<bool> UpdateAsync(Locality locality, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true);
    }
}
