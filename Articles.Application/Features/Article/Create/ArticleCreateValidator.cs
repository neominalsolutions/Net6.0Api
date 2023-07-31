using Articles.Application.Dtos;
using Articles.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Application.Features.Article.Create
{
  public class ArticleCreateValidator:AbstractValidator<ArticleCreateDto>
  {
    private readonly IArticleRepository articleRepository;

    public ArticleCreateValidator(IArticleRepository articleRepository)
    {
      this.articleRepository = articleRepository;

      RuleFor(x => x.Title).NotEmpty().WithMessage("Title alanı boş geçilemez").NotNull().WithMessage("Title alanı boş geçilemez");
      RuleFor(x => x.Title).MaximumLength(100).WithMessage("100 karakter sınırı var");
      RuleFor(x => x.Body).Must(ContainsNotPermittedKey).WithMessage("Yasaklı kelimeler içeriyor");
     
    }

    private bool ContainsNotPermittedKey(string content)
    {
      // logic kontroller yapıldı validasyondan geçip geçmeyeceğine karar verdik.
      return true;
    }


  }
}
