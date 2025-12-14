using Business.Abstract;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result.Result;
using DataAccess.Abstract;
using Entities.Concrete;

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
            _brandDal.Add(brand);
            return new SuccessResult(message: "Constants.Messages");
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(message: "Constants.Messages");
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var result = _brandDal.GetAll();

            if(result.Count != 0)
            {
                return new SuccessDataResult<List<Brand>>(data: result, message: "");
            }

            return new ErrorDataResult<List<Brand>>(data: null, message: "Listelenecek veri bulunamadı.");
        }

        public IDataResult<Brand> GetById(int id)
        {
            var result = _brandDal.Get(p => p.Id.Equals(id));

            if (result is not null)
            {
                return new SuccessDataResult<Brand>(data: result, message: "");
            }

            return new ErrorDataResult<Brand>(data: null, message: "Listelenecek veri bulunamadı.");
        }


        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(message: "Marka başarıyla güncellendi.");
            }
    }
}
