using Articles.Core.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Net6._0Api.Attributes;
using Net6._0Api.Exceptions;
using System.Text;

namespace Net6._0Api.ServiceRegisteration
{
  public static class ApiServices
  {
    public static IServiceCollection RegisterApiServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();


      string key = configuration["JWT:PrivateKey"];
      var secretKey = Encoding.ASCII.GetBytes(key);

      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(opt =>
      {
        opt.RequireHttpsMetadata = false;
        opt.SaveToken = true;  // HttpContext üzerinde accessToken tut
        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {

          //ValidateAudience = true,
          //ValidateIssuer = true,
          ValidateIssuer = false,
          ValidateAudience = false,
          ValidateIssuerSigningKey = true,
          ValidateLifetime = true, // expire olduysa validate etme,
          IssuerSigningKey = new SymmetricSecurityKey(secretKey), // keye göre validate

        };

      });


      services.AddAuthorization(opt =>
      {
        opt.AddPolicy("OnlyAdminPolicy", policy =>
        {
          policy.RequireAuthenticatedUser();
          policy.RequireRole("Admin");
          policy.RequireClaim("Age", "18", "19", "20");
        });
      });


      services.AddScoped<IJwtService, MicrosoftJwtBearerService>();

      services.AddTransient<LocalException>();
      services.AddScoped<PermissionFilterAttribute>();


      return services;
    }
  }
}
