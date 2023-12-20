using BaltaDesafioBlazor.Domain.Contexts.LocalityContext;
using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Commands.Create;
using BaltaDesafioBlazor.Tests.LocalityContextTests.Create.Mocks;

namespace BaltaDesafioBlazor.Tests.LocalityContextTests.Create;

[TestClass]
public class HandlerTests
{
    private readonly LocalityHandler _handler = new(
        new FakeCreateLocalityRepository(),
        null);

    [TestMethod]
    public async Task Should_Fail_When_Id_Is_Not_Available()
    {
        var command = new CreateLocalityCommand(
            "1234567",
            "Gotham City",
            "GC");

        var result = await _handler.ExecuteAsync(command);
        Assert.IsFalse(result.Success);
    }

    [TestMethod]
    public async Task Should_Fail_When_Locality_Already_Exists()
    {
        var command = new CreateLocalityCommand(
            "1478523",
            "Random City 1",
            "R1");

        var result = await _handler.ExecuteAsync(command);
        Assert.IsFalse(result.Success);
    }

    [TestMethod]
    public async Task Should_Create_Locality()
    {
        var command = new CreateLocalityCommand(
            "1478523",
            "Gotham City",
            "GC");

        var result = await _handler.ExecuteAsync(command);
        Assert.IsTrue(result.Success);
    }
}
