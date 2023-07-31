using Articles.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Core.EF
{
  public abstract class EFBaseRepository<TDbContext,TRootEntity, TKey> : IRepository<TRootEntity,TKey>
    where TDbContext : DbContext
    where TRootEntity : RootEntity<TKey>
  {
    protected TDbContext context;
    protected DbSet<TRootEntity> dbSet;

    public EFBaseRepository(TDbContext context)
    {
      this.context = context;
      this.dbSet = this.context.Set<TRootEntity>();

    }

    public virtual void Create(TRootEntity entity)
    {
      this.dbSet.Add(entity);
    }

    // Soft delete gibi de kurgulanabilir.
    public virtual void Delete(TKey key)
    {
      var entity = dbSet.Find(key);

      if (entity is null)
        throw new Exception("Entity Not Found");

      dbSet.Remove(entity);
    }

    public virtual TRootEntity Find(Expression<Func<TRootEntity, bool>> expression = null)
    {
      var entity = this.dbSet.FirstOrDefault(expression);

      if (entity is null)
        throw new Exception("Entity Not Found");

      return entity;
      
    }

    public virtual TRootEntity FindById(TKey key)
    {
      var entity = this.dbSet.Find(key);

      if (entity is null)
        throw new Exception("Entity Not Found");

      return entity;
    }

    public virtual void Update(TRootEntity entity)
    {
      dbSet.Update(entity);
    }

    public virtual List<TRootEntity> WhereList(Expression<Func<TRootEntity, bool>> expression = null)
    {
      return dbSet.Where(expression).AsNoTracking().ToList();
    }
  }
}
