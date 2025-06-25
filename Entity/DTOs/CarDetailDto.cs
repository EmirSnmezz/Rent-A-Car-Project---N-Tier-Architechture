using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string GearboxOption { get; set; }
        public string Color { get; set; }
        public int ModelYear { get; set; }
        public bool IsRented { get; set; }
        public int Price { get; set; }
        public int CarMileage { get; set; }
    }
}
