using System.Linq.Expressions;
using Entities.Abstract;

namespace DataAccess.Abstract.Base
{
    public interface IEntityRepository<T> where T : class, IEntity
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetById(Expression<Func<T, bool>> filter);
    }
}
