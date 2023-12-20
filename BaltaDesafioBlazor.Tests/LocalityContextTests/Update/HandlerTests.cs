using BaltaDesafioBlazor.Domain.Contexts.LocalityContext;
using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Commands.Update;
using BaltaDesafioBlazor.Tests.LocalityContextTests.Update.Mocks;

namespace BaltaDesafioBlazor.Tests.LocalityContextTests.Update;

[TestClass]
public class HandlerTests
{
    private readonly LocalityHandler _handler = new(
        new FakeUpdateLocalityRepository(),
        new FakeUpdateLocalityQueryHandler());

    [TestMethod]
    public async Task Should_Fail_When_New_Id_Is_Not_Available()
    {
        var command = new UpdateLocalityCommand(
            "1112223",
            "4445556",
            "Gotham City",
            "GC");

        var result = await _handler.ExecuteAsync(command);
        Assert.IsFalse(result.Success);
    }

    [TestMethod]
    public async Task Should_Fail_When_Locality_Is_Not_Available()
    {
        var command = new UpdateLocalityCommand(
            "1112223",
            "7896345",
            "Random City 3",
            "R3");

        var result = await _handler.ExecuteAsync(command);
        Assert.IsFalse(result.Success);
    }

    [TestMethod]
    public async Task Should_Fail_When_Locality_Does_Not_Exists_Locality()
    {
        var command = new UpdateLocalityCommand(
            "7896345",
            "1112223",
            "Gotham City",
            "GC");

        var result = await _handler.ExecuteAsync(command);
        Assert.IsFalse(result.Success);
    }

    [TestMethod]
    public async Task Should_Update_Locality()
    {
        var command = new UpdateLocalityCommand(
            "1112223",
            "7896345",
            "Gotham City",
            "GC");

        var result = await _handler.ExecuteAsync(command);
        Assert.IsTrue(result.Success);
    }
}
