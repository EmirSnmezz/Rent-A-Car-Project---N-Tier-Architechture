using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EfCarDal;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ICarService, CarManager>();
builder.Services.AddScoped<ICarDal, EfCarDal>();
builder.Services.AddSingleton<DbContext, RentalCarDbContext>();

var app = builder.Build();

app.MapControllers();

app.Run();
