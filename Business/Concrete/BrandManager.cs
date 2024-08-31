using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.Name.Length < 2)
            {
                return new ErrorResult(Messages.InvalidBrandName);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var brands = _brandDal.GetAll();
            if (brands.Count > 0)
            {
                return new SuccessDataResult<List<Brand>>(brands, Messages.BrandListed);
            }
            else
            {
                return new ErrorDataResult<List<Brand>>(Messages.BrandNotFound);
            }
        }

        public IDataResult<List<Brand>> GetByBrandId(int id)
        {
            var brands = _brandDal.GetAll(b => b.Id == id);
            if (brands.Count > 0)
            {
                return new SuccessDataResult<List<Brand>>(brands, Messages.BrandFound);
            }
            else
            {
                return new ErrorDataResult<List<Brand>>(Messages.BrandNotFound);
            }
        }

        public IResult Update(Brand brand)
        {
            if (brand.Name.Length < 2)
            {
                return new ErrorResult(Messages.InvalidBrandName);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        public IDataResult<Brand> GetById(int id)
        {
            var brand = _brandDal.Get(b => b.Id == id);
            if (brand != null)
            {
                return new SuccessDataResult<Brand>(brand, Messages.BrandFound);
            }
            else
            {
                return new ErrorDataResult<Brand>(Messages.BrandNotFound);
            }
        }
    }
}
