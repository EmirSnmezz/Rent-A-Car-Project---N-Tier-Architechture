

using Entities.Abstract;

namespace Entities.Concrete
{
    public class Model : IEntity
    {
        public string BrandId { get; set; }
        public Brand? Brand { get; set; }
        public string Name { get; set; }
    }
}
