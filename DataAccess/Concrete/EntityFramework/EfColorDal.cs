using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Color = Entities.Concrete.Color;
using DataAccess.Concrete.Base;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EntityRepositoryBase<Color>, IColorDal
    {
        public EfColorDal(DbContext context) : base(context)
        {
        }
    }
}
