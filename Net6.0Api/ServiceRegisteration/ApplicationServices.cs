using Articles.Application.Dtos;
using Articles.Application.Mappings;

namespace Net6._0Api.ServiceRegisteration
{
  public static class ApplicationServices
  {
    public static IServiceCollection RegisterApplicationService(this IServiceCollection services)
    {

      // reflection ile application libden referanse al
      services.AddAutoMapper(typeof(ArticleMapping));

      services.AddMediatR(opt =>
      {
        // doğru bir katman seçebilmek için refrection assembly load ettik.
        opt.RegisterServicesFromAssemblyContaining<ArticleCreateDto>();

      });

      return services;
    }

  }
}
