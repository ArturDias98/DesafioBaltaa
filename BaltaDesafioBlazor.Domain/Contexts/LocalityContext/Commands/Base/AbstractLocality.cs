using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Validators.Command;
using FluentValidation.Results;

namespace BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Commands.Base;

public abstract class AbstractLocality
{
    protected AbstractLocality(string id, string city, string state)
    {
        Id = id.Trim();
        City = city.Trim();
        State = state.Trim();
    }

    public string Id { get; }
    public string City { get; }
    public string State { get; set; }

    public ValidationResult Validate()
        => new AbstractLocalityValidator().Validate(this);
}
