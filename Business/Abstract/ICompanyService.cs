using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result.Result;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        IDataResult<List<Company>> GetAll();
        IDataResult<Company> GetById(int id);
        IResult Add(Company company);
        IResult Update(Company company);
        IResult Delete(Company company);
    }
}
