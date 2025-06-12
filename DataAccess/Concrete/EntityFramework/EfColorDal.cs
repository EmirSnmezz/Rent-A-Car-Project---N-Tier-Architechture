using System.Drawing;
using DataAccess.Abstract;
using DataAccess.Concrete.Base;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Color = Entities.Concrete.Color;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EntityRepositoryBase<Color>, IColorDal
    {
        public EfColorDal(DbContext context) : base(context)
        {
            
        }
    }
}
