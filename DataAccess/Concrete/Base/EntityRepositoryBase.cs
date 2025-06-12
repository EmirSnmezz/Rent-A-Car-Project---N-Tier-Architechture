using System.Linq.Expressions;
using DataAccess.Abstract.Base;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Concrete.Base
{
    public class EntityRepositoryBase<T> : IEntityRepository<T> where T : class, IEntity, new()
    {

        public DbContext _context;
        public EntityRepositoryBase(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            EntityEntry addedEntity = _context.Set<T>().Entry(entity);
            EntityState state = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            EntityEntry deletedEntity = _context.Set<T>().Entry(entity);
            EntityState state = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            EntityEntry updatedEntity = _context.Set<T>().Entry(entity);
            EntityState state = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null 
                ? _context.Set<T>().ToList() 
                : _context.Set<T>().Where(filter).ToList();
        }

        public T GetById(Expression<Func<T, bool>> filter)
        {
            T entity =  _context.Set<T>().FirstOrDefault(filter);

            if(entity is not null)
            {
                return entity;
            }

            return null;
        }
    }
}
