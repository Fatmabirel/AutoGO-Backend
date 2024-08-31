using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.Name.Length < 2)
            {
                return new ErrorResult("Marka adı en az 2 karakter olmalıdır");
            }
            _brandDal.Add(brand);
            return new SuccessResult("Marka eklendi");
        }

        public IResult Delete(Brand brand)
        {
           _brandDal.Delete(brand);
            return new ErrorResult("Marka silindi");
        }

        public IDataResult<List<Brand>> GetAll()
        {
           return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        IDataResult<List<Brand>> IBrandService.GetByBrandId(int id)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.Id == id));
        }

        public IResult Update(Brand brand)
        {
            if (brand.Name.Length < 2)
            {
                return new ErrorResult("Marka adı en az 2 karakter olmalıdır");
            }
            _brandDal.Update(brand);
            return new SuccessResult("Marka güncellendi");
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.Id == id));
        }
    }
}
