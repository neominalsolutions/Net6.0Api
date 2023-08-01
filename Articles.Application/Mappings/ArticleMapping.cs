using Articles.Application.Dtos;
using Articles.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Application.Mappings
{
  public class ArticleMapping:Profile
  {
    public ArticleMapping()
    {
      CreateMap<Comment, ArticleCommentDto>();
      CreateMap<Article, ArticleWithCommentsDto>();
    }
  }
}
