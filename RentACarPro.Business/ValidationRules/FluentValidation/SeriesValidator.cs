using FluentValidation;
using RentACarPro.Entities.Concrete;

namespace RentACarPro.Business.ValidationRules.FluentValidation
{
    public class SeriesValidator : AbstractValidator<Series>
    {
        public SeriesValidator()
        {
            RuleFor(s => s.BrandId).NotEmpty();
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Name).MinimumLength(2);
            RuleFor(s => s.Name).MaximumLength(50);
        }
    }
}
