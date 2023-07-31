
using Articles.Application.Dtos;
using Articles.Domain.Entities;
using Articles.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Application.Articles
{
  public class ArticleCreateService
  {
    private readonly IArticleRepository articleRepository;

    public ArticleCreateService(IArticleRepository articleRepository)
    {
      this.articleRepository = articleRepository;
    }
    public void Create(ArticleCreateDto dto)
    {
      var article = new Article(name: dto.Title, description: dto.Body, "");

      //
      this.articleRepository.Create(article);

    }
  }
}
