using FluentValidation;

namespace Bread.API.Schemas.Accounts
{
    public class JsLoginRequestValidator : AbstractValidator<JsLoginRequest>
    {
        public JsLoginRequestValidator()
        {
            RuleFor(x => x.UserName).Length(2, 30).NotNull();
            RuleFor(x => x.Password).Length(0, 30);
        }
    }
}
