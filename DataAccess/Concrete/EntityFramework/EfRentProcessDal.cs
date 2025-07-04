﻿using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentProcessDal : EntityRepositoryBase<RentProcess, RentalCarDbContext>, IRentProcessDal
    {
        DbContext _context;
        public EfRentProcessDal(DbContext context) : base(context) { }
    }
}
