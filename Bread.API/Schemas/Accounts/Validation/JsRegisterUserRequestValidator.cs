using Bread.API.Helpers;
using Bread.Application.Services;
using Bread.Domain.Entities;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Identity;

namespace Bread.API.Schemas.Accounts
{
    public class JsRegisterUserRequestValidator : AbstractValidator<JsRegisterUserRequest>
    {
        public JsRegisterUserRequestValidator(IUserValidationService userValidationService)
        {
            RuleFor(x => x.FormalName)
                .MaximumLength(255);

            RuleFor(x => x.PreferredName)
                .NotEmpty()
                .Length(1, 255);

            RuleFor(x => x.Email)
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .MustAsync(userValidationService.IsEmailUnique)
                .WithMessage("Email already taken");

            RuleFor(x => x.UserName)
                .Length(2, 30)
                .Matches("[A-Za-z0-9._]");

            RuleFor(x => x.Password).Password(6);
        }
    }
}
