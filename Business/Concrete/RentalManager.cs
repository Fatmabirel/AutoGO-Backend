using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private readonly ICarDal _carDal;

        public RentalManager(IRentalDal rentalDal, ICarDal carDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var car = _carDal.Get(c => c.Id == rental.CarId);
            // Arabanın mevcut durumunu kontrol et
            var activeRental = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);

            if (activeRental != null)
            {
                return new ErrorResult(Messages.CarIsAlreadyRented); // Araç zaten kiralanmışsa hata döndür
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var rentals = _rentalDal.GetAll();
            if (rentals.Count == 0)
            {
                return new ErrorDataResult<List<Rental>>(Messages.RentalsListed);
            }
            return new SuccessDataResult<List<Rental>>(rentals, Messages.RentalsListed);
        }

        public IDataResult<Rental> GetByCarId(int carId)
        {
            var rental = _rentalDal.Get(r => r.CarId == carId);
            if (rental == null)
            {
                return new ErrorDataResult<Rental>(Messages.RentalNotFound);
            }
            return new SuccessDataResult<Rental>(rental);
        }

        public IDataResult<List<Rental>> GetByCustomerId(int customerId)
        {
            var rentals = _rentalDal.GetAll(r => r.CustomerId == customerId);
            if (rentals.Count == 0)
            {
                return new ErrorDataResult<List<Rental>>(Messages.RentalNotFound);
            }
            return new SuccessDataResult<List<Rental>>(rentals);
        }

        public IDataResult<Rental> GetById(int id)
        {
            var rental = _rentalDal.Get(r => r.Id == id);
            if (rental == null)
            {
                return new ErrorDataResult<Rental>(Messages.RentalNotFound);
            }
            return new SuccessDataResult<Rental>(rental);
        }

        public IDataResult<bool> CheckCarAvailability(int carId, DateTime rentDate)
        {
            // Gelen rentDate'in saat kısmını sıfırlıyoruz
            rentDate = rentDate.Date;

            // Araç için hala iade edilmemiş kiralamaları alıyoruz
            var rentals = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null);

            // İade edilmemiş kiralamaları kontrol et
            foreach (var rental in rentals)
            {
                // Eğer kiralama tarihi belirtilen tarihe eşit veya daha önceyse ve iade edilmemişse
                if (rental.RentDate.Date == rentDate && (rental.ReturnDate == null || rentDate <= rental.ReturnDate?.Date))
                {
                    return new ErrorDataResult<bool>(false, Messages.CarIsAlreadyRented);
                }
            }

            return new SuccessDataResult<bool>(true);
        }


        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
