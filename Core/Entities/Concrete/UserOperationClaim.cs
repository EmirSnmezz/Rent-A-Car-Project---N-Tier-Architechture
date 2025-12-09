using Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public string UserId { get; set; }
        public string OperationClaimId { get; set; }
    }
}
