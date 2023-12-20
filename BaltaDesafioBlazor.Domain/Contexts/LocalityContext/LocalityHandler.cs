using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Create;
using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Delete;
using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Update;
using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Validators.Handler;
using BaltaDesafioBlazor.Domain.Contracts;
using BaltaDesafioBlazor.Domain.Entities;
using BaltaDesafioBlazor.Domain.Extensions;
using BaltaDesafioBlazor.Domain.Repositories;

namespace BaltaDesafioBlazor.Domain.Contexts.LocalityContext;

public sealed class LocalityHandler(ILocalityRepository localityRepository) :
    ICommandHandler<CreateLocalityCommand, GenericCommandResult>,
    ICommandHandler<UpdateLocalityCommand, GenericCommandResult>,
    ICommandHandler<DeleteLocalityCommand, GenericCommandResult>
{
    public async Task<GenericCommandResult> ExecuteAsync(CreateLocalityCommand command, CancellationToken cancellationToken = default)
    {
        if (!command.IsValid)
            return GenericCommandResult.ErrorResult(command.Errors);

        try
        {
            var validate = await new CreateLocalityHandlerValidator(localityRepository)
             .ValidateAsync(command, cancellationToken)
             .ConfigureAwait(false);

            if (!validate.IsValid)
            {
                return GenericCommandResult.ErrorResult(validate.GetErrors());
            }

            var locality = new Locality(command.Id, command.City, command.State);
            var result = await localityRepository
                .CreateAsync(locality, cancellationToken)
                .ConfigureAwait(false);

            return result
                ? GenericCommandResult.SuccessResult(locality.Id)
                : GenericCommandResult.ErrorResult(["Erro ao criar localidade"]);
        }
        catch (Exception)
        {
            return GenericCommandResult.ErrorResult(["Não foi possível realizar a operação de criar localidade"]);
        }
    }

    public async Task<GenericCommandResult> ExecuteAsync(UpdateLocalityCommand command, CancellationToken cancellationToken = default)
    {
        if (!command.IsValid)
            return GenericCommandResult.ErrorResult(command.Errors);

        bool result;

        var locality = new Locality(command.Id, command.City, command.State);

        if (command.OldId == command.Id)
        {
            result = await localityRepository
                .UpdateAsync(locality, cancellationToken)
                .ConfigureAwait(false);
        }
        else
        {
            result = await localityRepository
                .DeleteAndUpdateAsync(command.OldId, locality, cancellationToken)
                .ConfigureAwait(false);
        }

        return result
            ? GenericCommandResult.SuccessResult(locality.Id)
            : GenericCommandResult.ErrorResult(["Erro ao atualizar localidade"]);
    }

    public async Task<GenericCommandResult> ExecuteAsync(DeleteLocalityCommand command, CancellationToken cancellationToken = default)
    {
        if (!command.IsValid)
            return GenericCommandResult.ErrorResult(command.Errors);

        var result = await localityRepository
            .DeleteAsync(command.Id, cancellationToken)
            .ConfigureAwait(false);

        return result
            ? GenericCommandResult.SuccessResult(command.Id)
            : GenericCommandResult.ErrorResult(["Erro ao deletar localidade"]);
    }
}
