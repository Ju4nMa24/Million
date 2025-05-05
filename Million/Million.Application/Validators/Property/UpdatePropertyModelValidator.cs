using FluentValidation;
using Million.Application.Database.Commands.Property.UpdatePropertyCommand;

namespace Million.Application.Validators.Property
{
    public class UpdatePropertyModelValidator : AbstractValidator<UpdatePropertyModel>
    {
        public UpdatePropertyModelValidator()
        {
            RuleFor(x => x.IdProperty).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.CodeInternal).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Year).InclusiveBetween(1800, DateTime.UtcNow.Year);
            RuleFor(x => x.Status).NotEmpty().MaximumLength(50);
            RuleFor(x => x.IdOwner).NotEmpty();
            RuleFor(x => x.IdAddress).NotEmpty();
        }
    }

}
