using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCompayDal : EntityRepositoryBase<Company, RentalCarDbContext>, ICompanyDal
    {
        public EfCompayDal(DbContext context) : base(context)
        {
        }
    }
}
