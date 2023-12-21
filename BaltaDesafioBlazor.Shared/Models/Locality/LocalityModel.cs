using BaltaDesafioBlazor.Shared.EntityConstants;
using System.ComponentModel.DataAnnotations;

namespace BaltaDesafioBlazor.Shared.Models.Locality;

public class LocalityModel
{
    [Required(ErrorMessage = "O identificador é obrigatório")]
    [StringLength(maximumLength: LocalityConstants.ID_LENGTH, MinimumLength = LocalityConstants.ID_LENGTH, ErrorMessage = "O identificador deve possuír 7 caracteres")]
    [Display(Name = "Identificador")]
    public string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "A cidade é obrigatória")]
    [StringLength(maximumLength: LocalityConstants.CITY_MAX_LENGTH, MinimumLength = LocalityConstants.CITY_MIN_LENGTH, ErrorMessage = "A cidade de conter entre 3 a 80 caracteres")]
    [Display(Name = "Cidade")]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "O estado é obrigatório")]
    [StringLength(maximumLength: LocalityConstants.STATE_LENGTH, MinimumLength = LocalityConstants.STATE_LENGTH, ErrorMessage = "O estado deve conter 2 caracteres")]
    [Display(Name = "Estado")]
    public string State { get; set; } = string.Empty;
}
