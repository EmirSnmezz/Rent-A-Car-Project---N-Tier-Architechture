using System.Linq.Expressions;
using Entities.Abstract;

namespace Core.DataAccess.Abstract.Base
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
        TEntity GetById(Expression<Func<TEntity, bool>> filter);
    }
}
