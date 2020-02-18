using FluentValidation;

namespace Bread.API.Schemas.Groups
{
    public class JsModifyGroupValidator : AbstractValidator<JsModifyGroup>
    {
        public JsModifyGroupValidator()
        {
            RuleFor(x => x.Name).Length(5, 255);
            RuleFor(x => x.MissionStatement).Length(2, 3000);
            RuleFor(x => x.PrefaceImage).Length(2, 256);
            RuleFor(x => x.FacebookGroupId).Length(2, 256);
        }
    }
}
