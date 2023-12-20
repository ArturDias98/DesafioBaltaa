using BaltaDesafioBlazor.Domain.Entities;

namespace BaltaDesafioBlazor.Domain.Repositories;

public interface ILocalityRepository
{
    Task<bool> IsIdAvailableAsync(string id, CancellationToken cancellationToken = default);
    Task<bool> IsLocalityAvailableAsync(string city, string state, CancellationToken cancellationToken = default);

    Task<Locality?> GetAsync(string id, CancellationToken cancellationToken = default);

    Task<bool> CreateAsync(Locality locality, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Locality locality, CancellationToken cancellationToken = default);
    Task<bool> DeleteAndUpdateAsync(string oldId, Locality locality, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default);
}
