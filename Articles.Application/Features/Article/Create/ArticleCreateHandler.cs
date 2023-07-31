using Articles.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Articles.Domain;
using Articles.Domain.Entities;
using Articles.Domain.Repositories;
using Articles.Core.EF;

namespace Articles.Application
{
  public class ArticleCreateHandler : IRequestHandler<ArticleCreateDto, string>
  {
    private readonly IArticleRepository articleRepository;
    private readonly IUnitOfWork unitOfWork;

    public ArticleCreateHandler(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
    {
      this.articleRepository = articleRepository;
      this.unitOfWork = unitOfWork;

    }

    // Validation Web Api isteğini keser. 400 Bad Request
    public async Task<string> Handle(ArticleCreateDto request, CancellationToken cancellationToken)
    {
      // dto create update gibi işlemlerde entity olarak programcı tarafından kontrolü bir şekilde maplenir. auto mapper kullanmayız
      // veri tabanından veri okurken ise auto mapper kullanacağız.
      var article = new Article(name: request.Title, description: request.Body, "");

      this.articleRepository.Create(article);
      int result = this.unitOfWork.Commit();

      if(result > 0)
      {
        //cancellationToken.ThrowIfCancellationRequested();
        return await Task.FromResult(article.Id);
      }
      else
      {
        throw new Exception("Ekle sırasında bir hata oluştu");
      }

      
    }
  }
}
