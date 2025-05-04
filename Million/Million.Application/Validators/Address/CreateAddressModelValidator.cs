using FluentValidation;
using Million.Application.Database.Commands.Address.CreateAddressCommand;

namespace Million.Application.Validators.Address
{
    public class CreateAddressModelValidator : AbstractValidator<CreateAddressModel>
    {
        public CreateAddressModelValidator()
        {
            RuleFor(x => x.Street).NotEmpty().MaximumLength(100);
            RuleFor(x => x.City).NotEmpty().MaximumLength(50);
            RuleFor(x => x.State).NotEmpty().MaximumLength(50);
            RuleFor(x => x.ZipCode).NotEmpty().MaximumLength(10);
            RuleFor(x => x.Country).NotEmpty().MaximumLength(50);
        }
    }
}
