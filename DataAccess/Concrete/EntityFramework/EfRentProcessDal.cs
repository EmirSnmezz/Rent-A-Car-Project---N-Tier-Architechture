using DataAccess.Abstract;
using DataAccess.Concrete.Base;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentProcessDal : EntityRepositoryBase<RentProcess>, IRentProcessDal
    {
        DbContext _context;
        public EfRentProcessDal(DbContext context) : base(context) { }
    }
}
