using FluentValidation;

namespace Bread.API.Schemas.Posts
{
    public class JsModifyPostValidator : AbstractValidator<JsModifyPost>
    {
        public JsModifyPostValidator()
        {
            RuleFor(x => x.Title).Length(5, 255);
            RuleFor(x => x.Description).Length(2, 3000);
        }
    }
}
