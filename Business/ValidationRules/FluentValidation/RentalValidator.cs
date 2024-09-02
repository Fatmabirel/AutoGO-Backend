using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            // CarId alanı sıfırdan büyük olmalı.
            RuleFor(r => r.CarId).GreaterThan(0);

            // CustomerId alanı sıfırdan büyük olmalı.
            RuleFor(r => r.CustomerId).GreaterThan(0);

            // RentDate boş olamaz ve ReturnDate'ten önce olmalıdır.
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.ReturnDate).GreaterThan(r => r.RentDate)
                .When(r => r.ReturnDate.HasValue); // ReturnDate varsa, RentDate'ten büyük olmalı

            // ReturnDate, RentDate'ten önce olamaz.
            RuleFor(r => r.ReturnDate).GreaterThan(r => r.RentDate)
                .When(r => r.ReturnDate.HasValue); // ReturnDate varsa, RentDate'ten büyük olmalı
        }
    }
}
