using FluentValidation;

namespace Bread.API.Schemas.Albums
{
    public class JsModifyAlbumValidator : AbstractValidator<JsModifyAlbum>
    {
        public JsModifyAlbumValidator()
        {
            RuleFor(x => x.Title).Length(5, 255);
            RuleFor(x => x.Description).Length(2, 3000);
        }
    }
}
