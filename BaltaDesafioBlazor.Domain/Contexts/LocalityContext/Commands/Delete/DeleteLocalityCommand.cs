using BaltaDesafioBlazor.Domain.Contracts;
using BaltaDesafioBlazor.Domain.EntityConstants;

namespace BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Commands.Delete;

public sealed class DeleteLocalityCommand(string id) : ICommand
{
    public string Id { get; } = id;

    public bool IsValid => Id.Length == LocalityConstants.ID_LENGTH;

    public IReadOnlyCollection<string> Errors => ["Identificador Inválido"];
}
