using Business.Abstract;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public IResult Add(Company company)
        {
            _companyDal.Add(company);
            return new SuccessResult(message: "Şirket ekleme işlemi başarılı.");
        }

        public IResult Delete(Company company)
        {
            _companyDal.Delete(company);
            return new SuccessResult(message: "Şirket başarıyla silindi.");
        }

        public IDataResult<List<Company>> GetAll()
        {
            var result = _companyDal.GetAll();

            if(result.Count != 0)
            {
                return new SuccessDataResult<List<Company>>(data: result, message: "Şirket listeleme işlemi başarılı");
            }

            return new ErrorDataResult<List<Company>>(data: null, message: "Listelenecek Şirket Bilgisi Bulunamadı.");
        }

        public IDataResult<Company> GetById(int id)
        {
            var result =  _companyDal.Get(p => p.Id.Equals(id));

            if(result is not null)
            {
                return new SuccessDataResult<Company>(data: result, message: "Şirket bilgileri başarıyla getirildi.");
            }
            return new ErrorDataResult<Company>(data: null, message: "Şirket bulunamadı");
        }

        public IResult Update(Company company)
        {
            _companyDal.Update(company);
            return new SuccessResult(message: "Şirket başarıyla güncellendi.");

        }
    }
}
