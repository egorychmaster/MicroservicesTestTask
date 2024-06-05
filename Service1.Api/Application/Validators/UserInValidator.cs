using FluentValidation;
using Service.Contracts;
using Service1.Api.Models;

namespace Service1.Api.Application.Validators
{
    public class UserInValidator : AbstractValidator<UserInModel>
    {
        public UserInValidator()
        {
            RuleFor(e => e.Id).NotNull().Must(n => n > 0).WithMessage("The 'id' must be greater than zero.");
            RuleFor(e => e.Name).NotNull().NotEmpty().MaximumLength(LengthsConst.UserFldNameLenght);
            RuleFor(e => e.MiddleName).MaximumLength(LengthsConst.UserFldFldMiddleNameLenght);
            RuleFor(e => e.Surname).NotNull().NotEmpty().MaximumLength(LengthsConst.UserFldFldSurnameLenght);
            RuleFor(e => e.Email).NotNull().NotEmpty().MaximumLength(LengthsConst.UserFldFldEmailLenght);
        }
    }
}
