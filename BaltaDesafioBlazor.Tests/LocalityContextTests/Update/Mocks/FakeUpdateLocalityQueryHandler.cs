using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Queries;
using BaltaDesafioBlazor.Shared.Models.Locality;
using BaltaDesafioBlazor.Shared.Models.Result;

namespace BaltaDesafioBlazor.Tests.LocalityContextTests.Update.Mocks;

internal class FakeUpdateLocalityQueryHandler : ILocalityQueryHandler
{
    public Task<QueryPaginationResultModel<List<LocalityModel>>> GetLocalitiesAsync(int page = 0, int pageSize = 50, string state = "", string city = "", CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<QueryResultModel<LocalityModel>> GetLocalityAsync(string id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
