using Articles.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Domain.Services
{
  public class ArticlePublishService
  {
    private readonly IArticleRepository articleRepository;

    public ArticlePublishService(IArticleRepository articleRepository)
    {
      this.articleRepository = articleRepository;
    }

  }
}
