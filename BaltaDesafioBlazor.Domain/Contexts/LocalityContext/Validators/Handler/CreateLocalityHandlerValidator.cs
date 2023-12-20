using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Commands.Create;
using BaltaDesafioBlazor.Domain.Repositories;
using FluentValidation;

namespace BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Validators.Handler;

internal class CreateLocalityHandlerValidator : AbstractValidator<CreateLocalityCommand>
{
    public CreateLocalityHandlerValidator(ILocalityRepository repository)
    {
        RuleFor(i => i.Id)
            .MustAsync(repository.IsIdAvailableAsync)
            .WithMessage("Identificador não disponível");

        RuleFor(i => i)
            .MustAsync((create, CancellationToken) => repository.IsLocalityAvailableAsync(create.City, create.State, CancellationToken))
            .WithMessage("Localidade já cadastrada");
    }
}
