using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Commands.Update;
using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Queries;
using BaltaDesafioBlazor.Domain.Repositories;
using BaltaDesafioBlazor.Shared.Models.Locality;
using FluentValidation;

namespace BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Validators.Handler;

internal class UpdateLocalityHandlerValidator : AbstractValidator<UpdateLocalityCommand>
{
    public UpdateLocalityHandlerValidator(
        ILocalityRepository repository, 
        ILocalityQueryHandler queryHandler)
    {
        RuleFor(i => i)
            .MustAsync(async (comand, token) =>
            {
                if (comand.OldId == comand.Id)
                {
                    return true;
                }

                return await repository
                .IsIdAvailableAsync(comand.Id, token)
                .ConfigureAwait(false);
            })
            .WithMessage("Identificador não disponível");

        RuleFor(i => i)
            .MustAsync(async (command, token) =>
            {
                var result = await queryHandler
                .GetLocalityAsync(command.Id, token)
                .ConfigureAwait(false);

                if (!result.Success)
                {
                    throw new Exception("Não foi possível selecionar a localidade");
                }

                var locality = result.Result;

                if (LocalityHasChanged(locality, command.City, command.State))
                {
                    return await repository
                     .IsLocalityAvailableAsync(command.City, command.State, token)
                     .ConfigureAwait(false);
                }

                return true;
            })
            .WithMessage("Localidade já cadastrada");
    }

    private static bool LocalityHasChanged(LocalityModel locality, string city, string state)
    {
        if (!string.Equals(locality.City, city))
        {
            return true;
        }

        if (!string.Equals(locality.State, state))
        {
            return true;
        }

       return false;
    }
}
