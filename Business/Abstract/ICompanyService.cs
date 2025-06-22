using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        List<Company> GetAll();
        Company GetById(int id);
        void Add(Company company);
        void Update(Company company);
        void Delete(Company company);
    }
}
