using Articles.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Articles.Domain;
using Articles.Domain.Entities;

namespace Articles.Application
{
  public class ArticleCreateHandler : IRequestHandler<ArticleCreateDto>
  {
    // Validation Web Api isteğini keser. 400 Bad Request
    public Task Handle(ArticleCreateDto request, CancellationToken cancellationToken)
    {
      // dto create update gibi işlemlerde entity olarak programcı tarafından kontrolü bir şekilde maplenir. auto mapper kullanmayız
      // veri tabanından veri okurken ise auto mapper kullanacağız.
      var article = new Article(name: request.Title, description: request.Body, "");
      article.SetContent(request.Body);
      article.SetDescription(request.Title);
      article.SetName(request.Title);

      // kod blogunun çalışacağı kısım.
      throw new NotImplementedException();
    }
  }
}
