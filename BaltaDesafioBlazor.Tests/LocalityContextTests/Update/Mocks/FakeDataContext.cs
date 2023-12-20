using BaltaDesafioBlazor.Domain.Entities;

namespace BaltaDesafioBlazor.Tests.LocalityContextTests.Update.Mocks;

internal static class FakeDataContext
{
    public static List<Locality> Context =
    [
        new Locality("1112223", "Random City 1", "R1"),
        new Locality("4445556", "Random City 2", "R2"),
        new Locality("7778886", "Random City 3", "R3"),
    ];
}
