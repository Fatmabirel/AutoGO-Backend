using Business.Abstract;
using Business.Constants;
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
                return new SuccessResult(Messages.CarAdded); // Updated
            }
            else
            {
                return new ErrorResult(Messages.InvalidCarPrice + " ve " + Messages.InvalidCarDescription); // Updated
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted); // Updated
        }

        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Car>>(result, Messages.CarListed); // Updated
            }
            else
            {
                return new ErrorDataResult<List<Car>>(Messages.CarNotFound); // Updated
            }
        }

        public IDataResult<Car> GetById(int id)
        {
            var car = _carDal.Get(c => c.Id == id);
            if (car == null)
            {
                return new ErrorDataResult<Car>(Messages.CarNotFound);
            }
            return new SuccessDataResult<Car>(car, Messages.CarFound);
        }


        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var result = _carDal.GetCarDetails();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarDetailsListed); // Updated
            }
            else
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.CarDetailsNotFound); // Updated
            }
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated); // Updated
        }
    }
}
