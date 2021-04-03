using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(b => b.CardName).MinimumLength(2).WithMessage("Kart adı minimum 2 karakter olabilir");
            RuleFor(b => b.CardNumber).CreditCard().WithMessage("Geçerli bir kredi kartı girin");
            RuleFor(b => b.Cvv).Length(3).WithMessage("Geçerli bir Cvv bilgisi girin");
            RuleFor(b => b.UserId).NotEmpty();
        }
    }
}
