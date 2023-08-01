using Articles.Core.JWT;
using Articles.Infra.EF.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Net6._0Api.Dtos;
using System.Security.Claims;
using System.Security.Principal;

namespace Net6._0Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TokensController : ControllerBase
  {
    private readonly IJwtService jwtService;
    private readonly IConfiguration configuration;
    private readonly UserManager<AppUser> userManager;
    private readonly RoleManager<AppRole> roleManager;
    private readonly SignInManager<AppUser> signInManager;



    public TokensController(IJwtService jwtService, IConfiguration configuration, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
    {
      this.jwtService = jwtService;
      this.configuration = configuration;
      this.userManager = userManager;
      this.roleManager = roleManager;
      this.signInManager = signInManager;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> GenerateToken([FromBody] TokenRequestDto dto)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var user = await this.userManager.FindByNameAsync(dto.Username);

      if (user is not null)
      {
        var checkPassword = await this.userManager.CheckPasswordAsync(user, dto.Password);

        if (checkPassword)
        {
          //var userRoles = this.userManager.Users.Where(x=> x.Id == user.Id).SelectMany(x=> x.role)

          var userRoles = await this.userManager.GetRolesAsync(user);
          var userClaims = await this.userManager.GetClaimsAsync(user);



          var claims = new List<Claim>
          {
            new Claim("sub",user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role , string.Join(",",userRoles)),
          //new Claim("Age","18")

          };

          foreach (var item in userClaims)
          {
            claims.Add(new Claim(item.Type, item.Value));
          }



          string privateKey = this.configuration.GetSection("JWT").GetSection("PrivateKey").Value;
          string privateKey2 = this.configuration["JWT:PrivateKey"];

          var identity = new ClaimsIdentity(claims); // claims değerlerini üstünde tutan sınıf.

          var response = this.jwtService.GetAccessToken(identity, privateKey2, 30);

          return Ok(response);

        } 
        else
        {
          return BadRequest(new { message = "Kullanıcı adı veya parola hatalı" });
        }

        //this.signInManager.exte
      }
      else
      {
        return BadRequest(new { message = "Kullanıcı adı veya parola hatalı" });
      }
    }

    /*

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

    */

  }
}
