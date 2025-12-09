

using Entities.Abstract;

namespace Entities.Concrete
{
    public class Company : IEntity
    {
        public string Name { get; set; }
        public string TaxNumber { get; set; }
    }
}
