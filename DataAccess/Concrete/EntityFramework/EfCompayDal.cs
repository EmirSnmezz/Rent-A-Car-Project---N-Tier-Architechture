using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.Base;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCompayDal : EntityRepositoryBase<Company>, ICompanyDal
    {
        public EfCompayDal(RentalCarDbContext context) : base(context)
        {
        }
    }
}
