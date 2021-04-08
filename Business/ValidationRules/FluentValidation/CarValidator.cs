using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(100);
            RuleFor(c => c.ModelYear).GreaterThan(1950);
            RuleFor(c => c.ModelYear).LessThan(DateTime.Now.Year);
            RuleFor(b => b.FindeksScore).ExclusiveBetween(0, 1901);
        }
    }
}
