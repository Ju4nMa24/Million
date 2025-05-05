using FluentValidation;
using Million.Application.Database.Commands.Owner.UpdateOwnerCommand;
using Million.Common.Utilities;

namespace Million.Application.Validators.Owner
{
    public class UpdateOwnerModelValidator : AbstractValidator<UpdateOwnerModel>
    {
        public UpdateOwnerModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.Birthday).NotEmpty().LessThan(DateTime.UtcNow);
            RuleFor(x => x.Photo).NotEmpty().MaximumLength(200);
            RuleFor(x => x.OldEmail).NotEmpty().MinimumLength(10).MaximumLength(200).EmailAddress();
        }
    }

}
