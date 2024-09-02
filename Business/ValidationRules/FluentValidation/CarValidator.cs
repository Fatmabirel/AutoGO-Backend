using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            // DailyPrice alanı boş olamaz ve 0'dan büyük olmalı.
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);

            RuleFor(c => c.ModelYear).NotEmpty();

            // Description alanı boş olamaz ve en az 10 karakter olmalı.
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(5);

            // BrandId ve ColorId alanları boş olamaz.
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
        }
    }
}
