using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Base;
using Entities.Concrete;
using Entities.Consts;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfCarDal
{
    public class EfCarDal : EntityRepositoryBase<Car>, ICarDal
    {
        private RentalCarDbContext _context;
        public EfCarDal(RentalCarDbContext context) : base(context) 
        {
            _context = context;
        }

        public List<Car> GetAllByBrand(string brandId)
        {
            List<Car> cars = null;

            
            
                cars = _context.Set<Car>().Where(p => p.BrandId == brandId).ToList();
            

            return cars;
        }

        public List<Car> GetAllByColor(string ColorId)
        {
            List<Car> cars = null;
            cars = _context.Set<Car>().Where(p => p.ColorId == ColorId).ToList();
            
            return cars;
        }

        public List<Car> GetAllByGearBoxOption(GearBoxOptionEnum gearboxOption)
        {
            List<Car> cars = null;
            cars = _context.Set<Car>().Where(p => p.GearBoxOption == gearboxOption.ToString()).ToList();

            return cars;
        }

        public List<Car> GetAllByModelYear(int modelYear)
        {
            List<Car> cars = null;
            cars = _context.Set<Car>().Where(p => p.ModelYear == modelYear).ToList();
            

            return cars;
        }

        public List<Car> GetAllByPrice(int minPrice = 0, int maxPrice = 0)
        {
            List<Car> cars = null;  
            cars = _context.Set<Car>().Where(p => minPrice <= p.Price && maxPrice >= p.Price).ToList();

            return cars;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            List<CarDetailDto> carDetail;

                carDetail = (from c in _context.Cars
                             join b in _context.Brands
                             on c.BrandId equals b.Id
                             join color in _context.Colors
                             on c.ColorId equals color.Id
                             join model in _context.Models
                             on c.ModelId equals model.Id

                             select new CarDetailDto
                             {
                                 BrandName = b.Name,
                                 Model = model.Name,
                                 CarMileage = c.CarMileage,
                                 Color = color.Name,
                                 GearboxOption = c.GearBoxOption,
                                 ModelYear = c.ModelYear,
                                 Price = c.Price,
                                 IsRented = c.IsRented
                             }).ToList();
            
            return carDetail;
        }
    }
}
