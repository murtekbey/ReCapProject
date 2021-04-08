using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class FindeksScoreValidator : AbstractValidator<FindeksScore>
    {
        public FindeksScoreValidator()
        {
            RuleFor(b => b.CustomerId).NotEmpty();
            RuleFor(b => b.Score).ExclusiveBetween(0, 1901);
        }
    }
}
