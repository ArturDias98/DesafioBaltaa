using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Commands.Base;
using BaltaDesafioBlazor.Domain.EntityConstants;
using FluentValidation;

namespace BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Validators.Command;

internal class AbstractLocalityValidator : AbstractValidator<AbstractLocality>
{
    public AbstractLocalityValidator()
    {
        RuleFor(i => i.Id)
            .NotNull()
            .NotEmpty()
            .Must(i => i.Length == LocalityConstants.ID_LENGTH)
            .WithMessage("Identificador inválido");

        RuleFor(i => i.City)
            .NotNull()
            .NotEmpty()
            .Length(LocalityConstants.CITY_MIN_LENGTH, LocalityConstants.CITY_MAX_LENGTH)
            .WithMessage("Cidade inválida");

        RuleFor(i => i.State)
            .NotNull()
            .NotEmpty()
            .Must(i => i.Length == LocalityConstants.STATE_LENGTH)
            .WithMessage("Estado inválido");
    }
}
