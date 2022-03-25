using FluentValidation;
using RentACarPro.Entities.Concrete;

namespace RentACarPro.Business.ValidationRules.FluentValidation
{
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(m => m.BrandId).NotEmpty();
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Name).MinimumLength(2);
            RuleFor(m => m.Name).MaximumLength(50);
        }
    }
}