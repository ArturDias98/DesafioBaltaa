using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Commands.Base;
using BaltaDesafioBlazor.Domain.Contracts;
using BaltaDesafioBlazor.Domain.Extensions;

namespace BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Commands.Create;

public sealed class CreateLocalityCommand(string id, string city, string state) : AbstractLocality(id, city, state), ICommand
{
    public bool IsValid
        => Validate().IsValid;

    public IReadOnlyCollection<string> Errors
        => Validate().GetErrors();
}
