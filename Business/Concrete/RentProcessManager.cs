using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentProcessManager : IRentProcessService
    {
        IRentProcessDal _rentProcessDal;

        public RentProcessManager(IRentProcessDal rentProcessDal)
        {
            _rentProcessDal = rentProcessDal;
        }
        public void Add(RentProcess rentProcess)
        {
            _rentProcessDal.Add(rentProcess);
        }

        public void Delete(RentProcess rentProcess)
        {
            _rentProcessDal.Delete(rentProcess);
        }

        public List<RentProcess> GetAll()
        {
            return _rentProcessDal.GetAll();
        }

        public RentProcess GetById(int id)
        {
            return _rentProcessDal.GetById(p => p.Id == id);
        }

        public void Update(RentProcess rentProcess)
        {
            _rentProcessDal.Update(rentProcess);
        }
    }
}
