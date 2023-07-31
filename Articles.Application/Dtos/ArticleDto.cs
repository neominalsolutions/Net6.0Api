using System.Text.Json.Serialization;

namespace Articles.Application.Dtos
{
    public class ArticleDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string? Name { get; set; }

        [JsonPropertyName("body")]
        public string? Description { get; set; }

    }
}
