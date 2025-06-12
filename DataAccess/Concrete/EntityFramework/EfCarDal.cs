using DataAccess.Abstract;
using DataAccess.Concrete.Base;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Consts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfCarDal
{
    public class EfCarDal : EntityRepositoryBase<Car>, ICarDal
    {
        public EfCarDal(DbContext context) : base(context)
        {

        }
        public List<Car> GetAllByBrand(int brandId)
        {
            List<Car> cars = null;

            using (RentalCarDbContext context = new RentalCarDbContext())
            {
                cars = context.Set<Car>().Where(p => p.BrandId == brandId).ToList();
            }

            return cars;
        }

        public List<Car> GetAllByColor(int ColorId)
        {
            List<Car> cars = null;

            using (RentalCarDbContext context = new RentalCarDbContext())
            {
                cars = context.Set<Car>().Where(p => p.ColorId == ColorId).ToList();
            }

            return cars;
        }

        public List<Car> GetAllByGearBoxOption(GearBoxOptionEnum gearboxOption)
        {
            List<Car> cars = null;

            using (RentalCarDbContext context = new RentalCarDbContext())
            {
                cars = context.Set<Car>().Where(p => p.GearBoxOption == gearboxOption.ToString()).ToList();
            }

            return cars;
        }

        public List<Car> GetAllByModelYear(int modelYear)
        {
            List<Car> cars = null;

            using (RentalCarDbContext context = new RentalCarDbContext())
            {
                cars = context.Set<Car>().Where(p => p.ModelYear == modelYear).ToList();
            }

            return cars;
        }

        public List<Car> GetAllByPrice(int minPrice = 0, int maxPrice = 0)
        {
            List<Car> cars = null;

            using (RentalCarDbContext context = new RentalCarDbContext())
            {
                cars = context.Set<Car>().Where(p => minPrice <= p.Price && maxPrice >= p.Price).ToList();
            }

            return cars;
        }
    }
}
