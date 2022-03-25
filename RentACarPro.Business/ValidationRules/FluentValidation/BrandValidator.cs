using FluentValidation;
using RentACarPro.Entities.Concrete;

namespace RentACarPro.Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.Name).MinimumLength(2);
            RuleFor(b => b.Name).MaximumLength(300);
        }
    }
}
