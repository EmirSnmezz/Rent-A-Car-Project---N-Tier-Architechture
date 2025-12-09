using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.Base;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentProcessDal : EntityRepositoryBase<RentProcess>, IRentProcessDal
    {
        DbContext _context;
        public EfRentProcessDal(DbContext context) : base(context) { }
    }
}
