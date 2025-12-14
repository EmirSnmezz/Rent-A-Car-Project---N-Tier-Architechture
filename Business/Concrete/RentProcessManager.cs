using Business.Abstract;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result.Result;
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
        public IResult Add(RentProcess rentProcess)
        {
            _rentProcessDal.Add(rentProcess);
            return new SuccessResult(message: "Kiralama işlemi başarılı");
        }

        public IResult Delete(RentProcess rentProcess)
        {
            _rentProcessDal.Delete(rentProcess);
            return new SuccessResult(message: "Kiralama işlem kaydı başarıyla silindi.");
        }

        public IDataResult<List<RentProcess>> GetAll()
        {
            var result =  _rentProcessDal.GetAll();

            if(result.Count != 0)
            {
                return new SuccessDataResult<List<RentProcess>>(data: result, message: "Kiralama işlemleri başarıyla listelendi.");
            }

            return new ErrorDataResult<List<RentProcess>>(data: null, message: "Listelenecek kiralama işlemi bulunamadı");
        }

        public IDataResult<RentProcess> GetById(int id)
        {
            var result = _rentProcessDal.Get(p => p.Id .Equals(id));

            if(result is not null)
            {
                return new SuccessDataResult<RentProcess>(data: result, message: "Kiralama işlemi bulundu");
            }

            return new ErrorDataResult<RentProcess>(data: null, message: "Kiralama işlemi bulunamadı");
        }

        public IResult Update(RentProcess rentProcess)
        {
            _rentProcessDal.Update(rentProcess);
            return new SuccessResult(message: "Kiralama işlemi başarıyla güncellendi.");
        }
    }
}
