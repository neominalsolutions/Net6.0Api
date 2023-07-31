using System.Net;

namespace Net6._0Api.Exceptions
{
  public class LocalException : IMiddleware
  {
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
      try
      {
        await next(context); // try blogunda request devam ettir dedik.
      }
      catch (Exception ex)
      {

        var errorObject = new
        {
          statusCode = HttpStatusCode.InternalServerError,
          message = ex.Message
        };

        await context.Response.WriteAsJsonAsync(errorObject);

      }
    }
  }
}
