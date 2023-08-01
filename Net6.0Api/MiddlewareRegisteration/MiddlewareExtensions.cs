using Net6._0Api.Exceptions;

namespace Net6._0Api.MiddlewareRegisteration
{
  public static class MiddlewareExtensions
  {
    public static IApplicationBuilder UseCustomException(this IApplicationBuilder applicationBuilder)
    {
      return applicationBuilder.UseMiddleware<LocalException>();
    } 
  }
}
