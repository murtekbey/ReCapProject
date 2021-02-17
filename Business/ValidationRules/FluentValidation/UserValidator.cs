using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Password).MinimumLength(7);
            RuleFor(u => u.Password).MaximumLength(55);
        }
    }
}
