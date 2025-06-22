﻿using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Color = Entities.Concrete.Color;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EntityRepositoryBase<Color, RentalCarDbContext>, IColorDal
    {
        public EfColorDal(DbContext context) : base(context)
        {
        }
    }
}
