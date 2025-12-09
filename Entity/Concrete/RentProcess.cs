
using Entities.Abstract;

namespace Entities.Concrete
{
    public class RentProcess : IEntity
    {
        public string CarId { get; set; }
        public Car Car { get; set; }
        public string CompanyId { get; set; }
        public Company Company { get; set; }
        public int Price { get; set; }
    }
}
