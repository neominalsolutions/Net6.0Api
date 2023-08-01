using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Articles.Application.Dtos
{
  public class ArticleCommentDto
  {
    [JsonPropertyName("comment")]
    public string? Text { get; set; }

    [JsonPropertyName("commentBy")]
    public string? CommentBy { get; set; }

  }
}
