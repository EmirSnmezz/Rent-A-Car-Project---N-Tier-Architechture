using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace ConsoleUI
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars = new List<Car>()
        {
            new Car()
            {
                Id = 1, 
                Brand = new Brand(){ Id = 1, Name = "BMW" },
                Color = new Color(){ Id = 1, Name = "White" },
                Company = new Company() { Id = 1, Name = "DkMotorsCompany", TaxNumber = ""},
                CarMileage = 155000,
                GearBoxOption = "Manuel",
                IsRented = false,
                ModelYear = 2015,
                Model = new Model() {Id = 1, Name = "M4 Comptetion", Brand = new Brand(){Id = 1, Name = "BMW"} }
            }
        };
        public void Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByColor(int ColorId)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByGearBoxOption()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByModelYear(int modelYear)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByPrice(int minPrice = 0, int maxPrice = 0)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Car Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
