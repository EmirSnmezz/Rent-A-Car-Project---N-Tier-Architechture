using DataAccess.Abstract;
using DataAccess.Concrete.Base;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCompayDal : EntityRepositoryBase<Company>, ICompanyDal
    {
        public EfCompayDal(DbContext context) : base(context)
        {
        }
    }
}
