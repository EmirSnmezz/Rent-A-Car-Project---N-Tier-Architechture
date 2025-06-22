using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentProcessService
    {
        List<RentProcess> GetAll();
        RentProcess GetById(int id);
        void Add(RentProcess rentProcess);
        void Update(RentProcess rentProcess);
        void Delete(RentProcess rentProcess);
    }
}
