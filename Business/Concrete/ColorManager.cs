using Business.Abstract;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(message: "Renk ekleme işlemi başarılı");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(message: "Renk silme işlemi başarılı");
        }

        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();

            if(result is not null)
            {
                return new SuccessDataResult<List<Color>>(data: result, message: "Renk listeleme işlemi başarılı");
            }

            return new ErrorDataResult<List<Color>>(data: null, message: "Listelenecek renk bulunamadı");
        }

        public IDataResult<Color> GetById(int id)
        {
            var result =  _colorDal.Get(p => p.Id.Equals(id));

            if (result is not null)
            {
                return new SuccessDataResult<Color>(data: result, message: "Renk listeleme işlemi başarılı");
            }

            return new ErrorDataResult<Color>(data: null, message: "Listelenecek renk bulunamadı");
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(message: "Renk güncelleme işlemi başarılı");

        }
    }
}
