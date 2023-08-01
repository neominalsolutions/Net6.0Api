using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Articles.Application.Dtos
{
  public class ArticleWithCommentsDto
  {
    [JsonPropertyName("articleId")]
    public string Id { get; set; }

    //[JsonPropertyName("title")]
    public string? Name { get; set; }

    [JsonPropertyName("body")]
    //[JsonIgnore]  Jsonna çıktısını vermemek için kullandık.
    public string? Description { get; set; }

    [JsonPropertyName("comments")]
    public List<ArticleCommentDto>? Comments { get; set; }


  }
}
