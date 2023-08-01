using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Net6._0Api.Dtos
{
  public class TokenRequestDto
  {
    [Required(ErrorMessage = "Username zorunludur")]
    [DefaultValue("ali")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Password zorunludur")]
    [DefaultValue("admin")]
    public string? Password { get; set; }

  }
}
