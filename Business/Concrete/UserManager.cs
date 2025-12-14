using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result.Result;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        public IUserDal _userDal { get; set; }
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(message: "Kullanıcı başarıyla eklendi");
        }

        public IDataResult<User> GetByEmailOrUserName(string emailOrUserName)
        {
            var result = _userDal.Get(u => u.Email == emailOrUserName);

            if(result is not null)
            {
                return new SuccessDataResult<User>(data: result, message: "Kullanıcı bulundu");
            }

            return new ErrorDataResult<User>(data: null, message: "Kullanıcı bulunamadı.");
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetCliams(user);

            if (result is not null)
            {
                return new SuccessDataResult<List<OperationClaim>>(data: result, message: "Kullanıcı bulundu");
            }

            return new ErrorDataResult<List<OperationClaim>>(data: null, message: "Kullanıcı bulunamadı.");
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);

            if (result is not null)
            {
                return new SuccessDataResult<User>(data: result, message: "Kullanıcı bulundu");
            }

            return new ErrorDataResult<User>(data: null, message: "Kullanıcı bulunamadı.");
        }
    }
}
