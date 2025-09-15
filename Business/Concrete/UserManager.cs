using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
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
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByEmailOrUserName(string emailOrUserName)
        {
            return _userDal.Get(u => u.Email == emailOrUserName);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetCliams(user);
        }

        public User GetByEmail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
