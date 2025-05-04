using FluentValidation;
using Million.Application.Database.Commands.Owner.CreateOwnerCommand;

namespace Million.Application.Validators.Owner
{
    public class CreateOwnerModelValidator : AbstractValidator<CreateOwnerModel>
    {
        public CreateOwnerModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Birthday).NotEmpty().LessThan(DateTime.UtcNow);
            RuleFor(x => x.Photo).NotEmpty().MaximumLength(200);
            RuleFor(x => x.IdAddress).NotEmpty();
        }
    }
}
