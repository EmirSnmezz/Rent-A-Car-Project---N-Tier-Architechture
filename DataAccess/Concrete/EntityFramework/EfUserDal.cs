using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Base;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EntityRepositoryBase<User, RentalCarDbContext>, IUserDal
    {
        RentalCarDbContext _context;
        public EfUserDal(RentalCarDbContext context) : base(context)
        {
            _context = context;
        }

        public List<OperationClaim> GetCliams(User user)
        {
            var result = from operationClaim in _context.OperationClaims
                         join userOperationClaim in _context.UserOperationClaims
                         on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id

                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

            return result.ToList();
        }
    }
}
