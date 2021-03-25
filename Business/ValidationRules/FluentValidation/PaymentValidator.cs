using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator: AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(b => b.PaymentDate).NotNull();
            RuleFor(x => x.CustomerId).NotNull();
            RuleFor(x => x.RentalId).NotNull();
            RuleFor(x => x.Amount).GreaterThan(0);
        }
    }
}
