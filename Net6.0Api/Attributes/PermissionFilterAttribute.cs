using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Net6._0Api.Attributes
{
  public class PermissionFilterAttribute : IActionFilter
  {
    // controller actiona girdikten sonra
    public void OnActionExecuted(ActionExecutedContext context)
    {
      // actiondan çıktıktan sonra loglama gibi durumlar için kullanırız.
    }

    // controller actiona girmeden önce kontrol et

    public void OnActionExecuting(ActionExecutingContext context)
    {
      if (!context.HttpContext.Request.Path.Value.Contains("api/Tokens"))
      {
        // manuel olarak şuan uygulamaya authenticated mıyım ?
        var authResult = context.HttpContext.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme).GetAwaiter().GetResult();

        var token = context.HttpContext.GetTokenAsync("access_token").GetAwaiter().GetResult();

        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {

          //string userName = context.HttpContext.User.Identity.Name;

          //if (context.HttpContext.User.IsInRole("Admin"))
          //{

          //}

          //if(context.HttpContext.User.HasClaim(x=> x.Type == "Age" && x.Value == "18"))
          //{

          //}

          var response = new { message = "Kullanıcı yekisi yok" };
          context.Result = new UnauthorizedObjectResult(response);
        }
      }
     

      
    }
  }
}
