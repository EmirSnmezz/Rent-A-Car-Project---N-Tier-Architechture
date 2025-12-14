using Business.Abstract;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(message: "Müşteri ekleme işlemi başarılı");
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(message: "Müşteri ekleme işlemi başarılı");
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();

            if(result.Count != 0)
            {
                return new SuccessDataResult<List<Customer>>(data: result, message: "Müşteri listeleme işlemi başarılı");
            }

            return new ErrorDataResult<List<Customer>>(message: "Listelenecek müşteri bulunamadı.");
        }

        public IDataResult<Customer> GetById(int id)
        {
            var result =  _customerDal.Get(p => p.Id.Equals(id));

            if(result is not null)
            {
                return new SuccessDataResult<Customer>(data: result, message: "Müşteri bilgileri bulundu.");
            }

            return new ErrorDataResult<Customer>(data: null, message: "Müşteri bilgileri bulunamadı");
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(message: "Müşteri güncelleme işlemi başarılı");

        }
    }
}
