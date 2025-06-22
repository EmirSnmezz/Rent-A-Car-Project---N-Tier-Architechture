using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfModelDal : EntityRepositoryBase<Model, RentalCarDbContext>, IModelDal
    {
        public EfModelDal(DbContext context) : base(context)
        {
        }
    }
}
