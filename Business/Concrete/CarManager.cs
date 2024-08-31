using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length > 2)
            {
                _carDal.Add(car);
                return new SuccessResult("Araba başarıyla eklendi.");
            }
            else
            {
                return new ErrorResult("Araba günlük fiyatı 0'dan büyük olmalıdır ve açıklama en az 2 karakter olmalıdır.");
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Araba başarıyla silindi.");
        }

        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Car>>(result, "Arabalar başarıyla getirildi.");
            }
            else
            {
                return new ErrorDataResult<List<Car>>("Araba bulunamadı.");
            }
        }

        public IDataResult<Car> GetById(int id)
        {
            var car = _carDal.Get(c => c.Id == id);
            if (car != null)
            {
                return new SuccessDataResult<Car>(car, "Araba başarıyla getirildi.");
            }
            else
            {
                return new ErrorDataResult<Car>("Araba bulunamadı.");
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var result = _carDal.GetCarDetails();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(result, "Araba detayları başarıyla getirildi.");
            }
            else
            {
                return new ErrorDataResult<List<CarDetailDto>>("Araba detayları bulunamadı.");
            }
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Araba başarıyla güncellendi.");
        }
    }
}
