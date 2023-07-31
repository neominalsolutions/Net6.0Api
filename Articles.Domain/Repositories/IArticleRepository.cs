using Articles.Core.EF;
using Articles.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Domain.Repositories
{
  public interface IArticleRepository:IRepository<Article,string>
  {
    Article FindArticleWithComments(string key);
  }
}
