using System.Linq.Expressions;
using Core.DataAccess.Abstract.Base;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Core.DataAccess.EntityFramework;

public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> 
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
{

    public DbContext _context;
    public EntityRepositoryBase(DbContext context)
    {
        _context = context;
    }

    public void Add(TEntity entity)
    {
        EntityEntry addedEntity = _context.Set<TEntity>().Entry(entity);
        EntityState state = EntityState.Added;
        addedEntity.State = state;
        _context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        EntityEntry deletedEntity = _context.Set<TEntity>().Entry(entity);
        EntityState state = EntityState.Deleted;
        deletedEntity.State = state;
        _context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        EntityEntry updatedEntity = _context.Set<TEntity>().Entry(entity);
        EntityState state = EntityState.Modified;
        _context.SaveChanges();
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[]? includes)
    {
        IQueryable<TEntity> result = _context.Set<TEntity>();

            foreach(var include in includes)
            {
                result = result.Include(include);      
            }

            if(filter is not null)
                return result.Where(filter).ToList();
            
        return result.ToList();
    }

    public TEntity GetById(Expression<Func<TEntity, bool>> filter)
    {
        TEntity entity =  _context.Set<TEntity>().FirstOrDefault(filter);

        if(entity is not null)
        {
            return entity;
        }

        return null;
    }
}
