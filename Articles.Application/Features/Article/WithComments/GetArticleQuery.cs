using Articles.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Application.Features.Article.WithComments
{
  public class GetArticleQuery:FilterDto, IRequest<List<ArticleWithCommentsDto>>
  {
  }
}
