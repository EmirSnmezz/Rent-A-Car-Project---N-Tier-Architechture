using Core.DataAccess.Abstract.Base;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetCliams(User user);
    }
}
