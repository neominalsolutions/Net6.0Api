using Articles.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Domain.Repositories
{
  public interface IArticleRepository
  {
    public void Create(Article article);
  }
}
