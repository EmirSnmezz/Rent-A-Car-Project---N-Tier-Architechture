using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.Base;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfModelDal : EntityRepositoryBase<Model>, IModelDal
    {
        public EfModelDal(DbContext context) : base(context)
        {
        }
    }
}
