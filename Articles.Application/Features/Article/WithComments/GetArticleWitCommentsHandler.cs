using Articles.Application.Dtos;
using Articles.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Application.Features.Article.WithComments
{
  public class GetArticleWitCommentsHandler : IRequestHandler<GetArticleQuery, List<ArticleWithCommentsDto>>
  {
    private readonly IArticleRepository articleRepository;
    private readonly IMapper mapper;

    public GetArticleWitCommentsHandler(IArticleRepository articleRepository, IMapper mapper)
    {
      this.articleRepository = articleRepository;
      this.mapper = mapper;
    }

    public async Task<List<ArticleWithCommentsDto>> Handle(GetArticleQuery request, CancellationToken cancellationToken)
    {

      var entities =  this.articleRepository.FindArticleWithComments();
      var dtos = this.mapper.Map<List<ArticleWithCommentsDto>>(entities);

      return await Task.FromResult<List<ArticleWithCommentsDto>>(dtos);
    }
  }
}
