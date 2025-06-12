using DataAccess.Abstract;
using DataAccess.Concrete.Base;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfModelDal : EntityRepositoryBase<Model>, IModelDal
    {
    }
}
