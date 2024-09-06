using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Color>>(result, Messages.ColorListed);
            }
            else
            {
                return new ErrorDataResult<List<Color>>(Messages.ColorNotFound);
            }
        }

        public IDataResult<List<Color>> GetByColorId(int id)
        {
            var result = _colorDal.GetAll(c => c.Id == id);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Color>>(result, Messages.ColorListed);
            }
            else
            {
                return new ErrorDataResult<List<Color>>(Messages.ColorNotFound);
            }
        }

        public IDataResult<Color> GetById(int id)
        {
            var color = _colorDal.Get(c => c.Id == id);
            if (color != null)
            {
                return new SuccessDataResult<Color>(color, Messages.ColorFound);
            }
            else
            {
                return new ErrorDataResult<Color>(Messages.ColorNotFound);
            }
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
