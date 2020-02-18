using FluentValidation;

namespace Bread.API.Schemas.Albums
{
    public class JsCreateAlbumValidator : AbstractValidator<JsCreateAlbum>
    {
        public JsCreateAlbumValidator()
        {
            RuleFor(x => x.Title).Length(5, 255);
            RuleFor(x => x.Description).Length(2, 3000);
        }
    }
}
