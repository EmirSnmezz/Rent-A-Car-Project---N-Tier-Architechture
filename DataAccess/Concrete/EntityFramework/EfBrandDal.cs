using DataAccess.Abstract;
using DataAccess.Concrete.Base;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EntityRepositoryBase<Brand> , IBrandDal
    {
        public EfBrandDal(DbContext context) : base(context)
        {
            
        }
    }
}
