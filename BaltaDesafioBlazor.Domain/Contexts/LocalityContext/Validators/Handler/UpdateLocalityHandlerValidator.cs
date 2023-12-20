using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Queries;
using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Update;
using BaltaDesafioBlazor.Domain.Repositories;
using FluentValidation;

namespace BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Validators.Handler;

internal class UpdateLocalityHandlerValidator : AbstractValidator<UpdateLocalityCommand>
{
    public UpdateLocalityHandlerValidator(ILocalityRepository repository, ILocalityQueryHandler queryHandler)
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
            .MustAsync(async (comand, token) =>
            {
                var result = await queryHandler
                .GetLocalityAsync(comand.Id, token)
                .ConfigureAwait(false);

                if (!result.Success)
                {
                    throw new Exception("Não foi possível selecionar a localidade");
                }

                var locality = result.Result;

                if (locality.City.Equals(comand.City) && locality.State.Equals(comand.State))
                {
                    return true;
                }

                return await repository
                .IsLocalityAvailableAsync(comand.City, comand.State, token)
                .ConfigureAwait(false);
            });
    }
}
