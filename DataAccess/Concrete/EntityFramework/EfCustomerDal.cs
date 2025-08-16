using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.Base;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EntityRepositoryBase<Customer, RentalCarDbContext>, ICustomerDal
    {
        public EfCustomerDal(DbContext context) : base(context)
        {
        }
    }
}
