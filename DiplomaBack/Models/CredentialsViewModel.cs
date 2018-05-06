using DiplomaBack.Validations;
using FluentValidation.Attributes;

namespace DiplomaBack.Models
{
    [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
