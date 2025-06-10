using Entities.Abstract;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public Brand Brand { get; set; }
        public Model Model { get; set; }
        public Color Color { get; set; }
        public Company Company { get; set; }
        public bool IsRented { get; set; }
        public int ModelYear { get; set; }
    }
}
