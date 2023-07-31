using Articles.Core.EF;
using Articles.Domain.Entities;
using Articles.Domain.Repositories;
using Articles.Infra.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Infra.EF.Repositories
{
  public sealed class EFArticleRepository : EFBaseRepository<AppDbContext, Article, string>, IArticleRepository
  {
    public EFArticleRepository(AppDbContext context) : base(context)
    {
    }

    public Article FindArticleWithComments(string key)
    {
      var entity = dbSet.Include(x => x.Comments).FirstOrDefault(x => x.Id == key);

      if (entity is null)
        throw new Exception("find error");

      return entity;
    }
  }
}
