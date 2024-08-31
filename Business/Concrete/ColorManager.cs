using Business.Abstract;
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

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult("Renk başarıyla eklendi.");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult("Renk başarıyla silindi.");
        }

        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Color>>(result, "Renkler başarıyla getirildi.");
            }
            else
            {
                return new ErrorDataResult<List<Color>>("Renk bulunamadı.");
            }
        }

        public IDataResult<List<Color>> GetByColorId(int id)
        {
            var result = _colorDal.GetAll(c => c.Id == id);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Color>>(result, "Renkler başarıyla getirildi.");
            }
            else
            {
                return new ErrorDataResult<List<Color>>("Renk bulunamadı.");
            }
        }

        public IDataResult<Color> GetById(int id)
        {
            var color = _colorDal.Get(c => c.Id == id);
            if (color != null)
            {
                return new SuccessDataResult<Color>(color, "Renk başarıyla getirildi.");
            }
            else
            {
                return new ErrorDataResult<Color>("Renk bulunamadı.");
            }
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult("Renk başarıyla güncellendi.");
        }
    }
}
