using FluentValidation;
using Million.Application.Database.Commands.Owner.UpdateOwnerCommand;

namespace Million.Application.Validators.Owner
{
    public class UpdateOwnerModelValidator : AbstractValidator<UpdateOwnerModel>
    {
        public UpdateOwnerModelValidator()
        {
            RuleFor(x => x.IdOwner).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Birthday).NotEmpty().LessThan(DateTime.UtcNow);
            RuleFor(x => x.Photo).NotEmpty().MaximumLength(200);
            RuleFor(x => x.IdAddress).NotEmpty();
        }
    }

}
