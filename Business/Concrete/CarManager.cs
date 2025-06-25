using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            
            if(car.Brand.Name.Length < 2 || car.Model.Name.Length < 2)
            {
                return new ErrorResult(Messages.CarNameIsValid);
            }

            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Başarılı");
        }

        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll();

            if(result is null)
            {
                return new ErrorDataResult<List<Car>>(result);
            }

            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            var result = _carDal.GetAll(p => p.BrandId == brandId);

            if (result is null)
            {
                return new ErrorDataResult<List<Car>>(result);
            }

            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<Car> GetById(int id)
        {
            var result =  _carDal.GetById(p => p.Id == id);

            if (result is null)
            {
                return new ErrorDataResult<Car>(result);
            }

            return new SuccessDataResult<Car>(result);

        }

        public IDataResult<List<Car>> GetByPrice(int minValue = 0, int maxValue = 0)
        {
           var result = _carDal.GetAll(p => p.Price > minValue && p.Price < maxValue);

            if (result is null)
            {
                return new ErrorDataResult<List<Car>>(result);
            }

            return new SuccessDataResult<List<Car>>(result);

        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Başarılı");
        }
    }
}
