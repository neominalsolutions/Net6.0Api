using Articles.Core.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net6._0Api.Dtos;
using System.Security.Claims;

namespace Net6._0Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TokensController : ControllerBase
  {
    private readonly IJwtService jwtService;
    private readonly IConfiguration configuration;

    public TokensController(IJwtService jwtService, IConfiguration configuration)
    {
      this.jwtService = jwtService;
      this.configuration = configuration;
    }

    [HttpPost]
    public IActionResult GenerateToken([FromBody] TokenRequestDto dto)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      
      if(dto.Username == "ali" && dto.Password == "admin")
      {
        // validated user

        var claims = new List<Claim>
        {
          new Claim("sub",Guid.NewGuid().ToString()),
          new Claim(ClaimTypes.Name, dto.Username),
          new Claim(ClaimTypes.Role , "Admin"),
          new Claim("Age","18")

        };

        var identity = new ClaimsIdentity(claims); // claims değerlerini üstünde tutan sınıf.
        string privateKey = this.configuration.GetSection("JWT").GetSection("PrivateKey").Value;
        string privateKey2 = this.configuration["JWT:PrivateKey"];

        var response = this.jwtService.GetAccessToken(identity, privateKey2, 30);

        return Ok(response);
      } 
      else
      {
        return BadRequest(new { message = "Kullanıcı adı veya parola hatalı" });
      }
     
    }

  }
}
