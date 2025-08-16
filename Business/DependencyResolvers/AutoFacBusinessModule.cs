using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.Base;
using DataAccess.Concrete.EfCarDal;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<EfRentProcessDal>().As<IRentProcessDal>().SingleInstance();
            builder.RegisterType<RentalCarDbContext>().As<DbContext>().SingleInstance();

            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .EnableClassInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
                {
                    Selector = new MethodInterceptionSelector()
                }).SingleInstance();
        }
    }
}
