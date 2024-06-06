using FluentValidation;
using Service.Common;
using Service1.Api.Models;

namespace Service1.Api.Application.Validators
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(e => e.Id).NotNull().Must(n => n > 0).WithMessage("The 'id' must be greater than zero.");
            RuleFor(e => e.Name).NotNull().NotEmpty().MaximumLength(TableFieldsConst.UserFldNameLenght);
            RuleFor(e => e.MiddleName).MaximumLength(TableFieldsConst.UserFldFldMiddleNameLenght);
            RuleFor(e => e.Surname).NotNull().NotEmpty().MaximumLength(TableFieldsConst.UserFldFldSurnameLenght);
            RuleFor(e => e.Email).NotNull().NotEmpty().MaximumLength(TableFieldsConst.UserFldFldEmailLenght);
        }
    }
}
