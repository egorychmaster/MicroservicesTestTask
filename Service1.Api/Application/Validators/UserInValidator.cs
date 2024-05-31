using FluentValidation;
using Service1.Api.Models;

namespace Service1.Api.Application.Validators
{
    public class UserInValidator : AbstractValidator<UserInModel>
    {
        public UserInValidator()
        {
            RuleFor(e => e.Number).NotNull().Must(n => n > 0).WithMessage("The 'number' must be greater than zero");
            RuleFor(e => e.Name).NotNull().NotEmpty();
            RuleFor(e => e.Surname).NotNull().NotEmpty();
            RuleFor(e => e.Email).NotNull().NotEmpty();
        }
    }
}
