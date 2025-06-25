
using Core.DataAccess.Abstract.Base;
using Entities.Concrete;
using Entities.Consts;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        public List<Car> GetAllByBrand(int brandId);
        public List<Car> GetAllByModelYear(int modelYear);
        public List<Car> GetAllByColor(int ColorId);
        public List<Car> GetAllByPrice(int minPrice = default, int maxPrice = default);
        public List<Car> GetAllByGearBoxOption(GearBoxOptionEnum gearboxOption);
        public List<CarDetailDto> GetCarDetails();
    }
}
