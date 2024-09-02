using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            // FirstName alanı boş olamaz ve en az 2 karakter uzunluğunda olmalı.
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);

            // LastName alanı boş olamaz ve en az 2 karakter uzunluğunda olmalı.
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);

            // Email alanı boş olamaz ve geçerli bir e-posta adresi formatında olmalı.
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();

            // Password alanı boş olamaz ve en az 6 karakter uzunluğunda olmalı.
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(6);
        }
    }
}
