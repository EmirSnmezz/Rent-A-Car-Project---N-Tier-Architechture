using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result.Result;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<Car>> GetByPrice(int minValue = default, int maxValue = default);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);

    }
}
