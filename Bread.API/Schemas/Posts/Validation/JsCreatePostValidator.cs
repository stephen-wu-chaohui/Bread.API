using FluentValidation;

namespace Bread.API.Schemas.Posts
{
    public class JsCreatePostValidator : AbstractValidator<JsCreatePost>
    {
        public JsCreatePostValidator()
        {
            RuleFor(x => x.Title).Length(5, 255);
            RuleFor(x => x.Description).Length(2, 3000);
        }
    }
}
