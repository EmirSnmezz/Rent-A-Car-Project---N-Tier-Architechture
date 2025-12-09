

using Entities.Abstract;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public int FindexPoint { get; set; }
        
    }
}
