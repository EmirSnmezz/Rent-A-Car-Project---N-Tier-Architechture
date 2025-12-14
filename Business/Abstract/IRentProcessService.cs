using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result.Result;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentProcessService
    {
        IDataResult<List<RentProcess>> GetAll();
        IDataResult<RentProcess> GetById(int id);
        IResult Add(RentProcess rentProcess);
        IResult Update(RentProcess rentProcess);
        IResult Delete(RentProcess rentProcess);
    }
}
