using Articles.Infra.EF.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Net6._0Api.Dtos;
using System.Net;

namespace Net6._0Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly UserManager<AppUser> userManager;
    private readonly RoleManager<AppRole> roleManager;

    public UsersController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
      this.userManager = userManager;
      this.roleManager = roleManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] TokenRequestDto dto)
    {
      var user = new AppUser();
      user.Id = Guid.NewGuid().ToString();
      user.UserName = dto.Username;
      user.Email = dto.Username;
      var result = await this.userManager.CreateAsync(user, dto.Password);

      if(result.Succeeded)
      {
        await this.userManager.AddClaimAsync(user, new System.Security.Claims.Claim("Age", "18"));

        await this.userManager.AddToRoleAsync(user, "Admin");
        await this.userManager.AddToRoleAsync(user, "Manager");

        return StatusCode(StatusCodes.Status201Created, user);
      } else
      {
        return BadRequest(result.Errors);
      }

     
    }
  }
}
