namespace Entities.Abstract
{
    public abstract class IEntity
    {

        protected IEntity()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
    }
}
