using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EntityRepositoryBase<Brand, RentalCarDbContext> , IBrandDal
    {
        public EfBrandDal(DbContext context) : base(context)
        {
            
        }
    }
}
