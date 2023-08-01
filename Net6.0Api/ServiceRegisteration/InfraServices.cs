using Articles.Core.EF;
using Articles.Domain.Repositories;
using Articles.Infra.EF.Contexts;
using Articles.Infra.EF.Identity;
using Articles.Infra.EF.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Net6._0Api.ServiceRegisteration
{
  public static class InfraServices
  {
    public static IServiceCollection RegisterInfraServices(this IServiceCollection services, IConfiguration configuration)
    {


      //builder.Services.AddSingleton<AppDbContext>();

      services.AddDbContext<AppDbContext>(opt =>
      {
        opt.UseSqlServer(configuration.GetConnectionString("Conn"));
      });


      // Identity Ayarları
      services.AddDbContext<AppIdentityDbContext>(opt =>
      {
        opt.UseSqlServer(configuration.GetConnectionString("Conn"));
      }
        );

      // Uygulama IdentityYapısını kullansın
      services.AddIdentity<AppUser, AppRole>(opt =>
      {

      }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppIdentityDbContext>();


      // Persistance ayarları
      services.AddScoped<IUnitOfWork, EFUnitOfWork<AppDbContext>>();
      services.AddScoped<IArticleRepository, EFArticleRepository>();


      return services;
    }
  }
}
