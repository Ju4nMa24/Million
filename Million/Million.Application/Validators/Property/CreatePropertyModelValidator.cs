using FluentValidation;
using Million.Application.Database.Commands.Property.CreatePropertyCommand;

namespace Million.Application.Validators.Property
{
    public class CreatePropertyModelValidator : AbstractValidator<CreatePropertyModel>
    {
        public CreatePropertyModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(150);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.CodeInternal).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Year).InclusiveBetween(1800, DateTime.UtcNow.Year);
            RuleFor(x => x.Status).NotEmpty().MaximumLength(50);
        }
    }
}
