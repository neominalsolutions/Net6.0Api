using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Articles.Application.Dtos
{
    public class ArticleCreateDto
    {
        [JsonPropertyName("title")]
        [Required]
        [DefaultValue("title")]
        public string? Title { get; set; }

        [JsonPropertyName("body")]
        [DefaultValue("body")]
        public string? Body { get; set; }

        [JsonPropertyName("likes")]
        [Required]
        public int? LikeCount { get; set; }


    }
}
