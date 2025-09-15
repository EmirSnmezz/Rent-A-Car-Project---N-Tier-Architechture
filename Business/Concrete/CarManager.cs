using System.Linq.Expressions;
using System.Reflection;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects;
using Core.Utilities.Business;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    // İş kurallarını tek tek method içerisine yazarsan kod spagetti olur. 
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(CarAddDto carDto)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountOfCategoryCorrect(carDto.BrandId));

            if (result != null)
                return result;

            var car = new Car
            {
                BrandId = carDto.BrandId,
                ModelId = carDto.ModelId,
                ColorId = carDto.ColorId,
                CompanyId = carDto.CompanyId,
                IsRented = carDto.IsRented,
                ModelYear = carDto.ModelYear,
                GearBoxOption = carDto.GearBoxOption,
                CarMileage = carDto.CarMileage,
                Price = carDto.Price,
            };

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

            var result = _carDal.GetAll(
            includes: new Expression<Func<Car, object>>[]
            {
                c => c.Brand,
                c => c.Model,
                c => c.Color
            }
            ).ToList();

            if (result is null)
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
            var result = _carDal.Get(p => p.Id == id);

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
            IResult result = BusinessRules.Run(CheckIfCarCountOfCategoryCorrect(car.BrandId));

            if(result != null)
                return result;

            _carDal.Update(car);

            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var result = _carDal.GetCarDetails();

            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        private IResult CheckIfCarCountOfCategoryCorrect(int brandId)
        {
            var result = _carDal.GetAllByBrand(brandId).Count;

            if (result >= 10)
                return new ErrorResult(Messages.ErrorOfCarAddedByBrandCount);

            return new SuccessResult();
        }
    }
}
