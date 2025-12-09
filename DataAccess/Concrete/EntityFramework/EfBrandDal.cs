using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.Base;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EntityRepositoryBase<Brand> , IBrandDal
    {
        public EfBrandDal(DbContext context) : base(context)
        {
            
        }
    }
}
