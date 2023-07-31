using Articles.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Core.EF
{
  public interface IRepository<TEntity, TKey> where TEntity:RootEntity<TKey>
  {
    void Create(TEntity entity);
    void Delete(TKey key);

    void Update(TEntity entity);

    List<TEntity> WhereList(Expression<Func<TEntity,bool>> expression = null);

    TEntity Find(Expression<Func<TEntity, bool>> expression = null);

    TEntity FindById(TKey key);
  }
}
