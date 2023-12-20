using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Validators.Command;
using FluentValidation.Results;

namespace BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Base;

public abstract class AbstractLocality
{
    protected AbstractLocality(string id, string city, string state)
    {
        Id = id;
        City = city;
        State = state;
    }

    public string Id { get;}
    public string City { get; }
    public string State { get; set; }

    public ValidationResult Validate()
        => new AbstractLocalityValidator().Validate(this);
}
