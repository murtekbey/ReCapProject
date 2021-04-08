using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.ImagePath).NotEmpty();
            RuleFor(r => r.Date).NotEmpty();
        }
    }
}
