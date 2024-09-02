using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            // CompanyName alanı boş olamaz ve en az 3 karakter uzunluğunda olmalı.
            RuleFor(c => c.CompanyName).NotEmpty();
            RuleFor(c => c.CompanyName).MinimumLength(3);

            // UserId alanı sıfırdan büyük olmalı.
            RuleFor(c => c.UserId).GreaterThan(0);
        }
    }
}
