using Articles.Application.Dtos;
using Articles.Application.Features.Article.Create;
using Articles.Application.Mappings;
using Articles.Core.EF;
using Articles.Core.JWT;
using Articles.Domain.Repositories;
using Articles.Infra.EF.Contexts;
using Articles.Infra.EF.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Net6._0Api.Attributes;
using Net6._0Api.Exceptions;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( opt =>
{
  opt.Filters.Add(new PermissionFilterAttribute());
  // bütün uygulama genelinde istekler filtrelenmiþ oluyorç
})
  .AddFluentValidation(opt =>
{
  opt.RegisterValidatorsFromAssemblyContaining<ArticleCreateValidator>();
});

// seviside ayaða kaldýrmayý unutmayalým.
builder.Services.AddScoped<PermissionFilterAttribute>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<LocalException>();



// reflection ile application libden referanse al
builder.Services.AddAutoMapper(typeof(ArticleMapping));

builder.Services.AddMediatR(opt =>
{
  // doðru bir katman seçebilmek için refrection assembly load ettik.
  opt.RegisterServicesFromAssemblyContaining<ArticleCreateDto>();

});

//builder.Services.AddSingleton<AppDbContext>();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
  opt.UseSqlServer(builder.Configuration.GetConnectionString("Conn"));
});

string key = builder.Configuration["JWT:PrivateKey"];
var secretKey = Encoding.ASCII.GetBytes(key);

builder.Services.AddAuthentication(x =>
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

builder.Services.AddAuthorization(opt =>
{
  opt.AddPolicy("OnlyAdminPolicy", policy =>
  {
    policy.RequireAuthenticatedUser();
    policy.RequireRole("Admin");
    policy.RequireClaim("Age", "18","19","20");
  });
});





builder.Services.AddScoped<IJwtService, MicrosoftJwtBearerService>();


// Persistance ayarlarý
builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork<AppDbContext>>();
builder.Services.AddScoped<IArticleRepository, EFArticleRepository>();


// middlewares
var app = builder.Build();



app.UseMiddleware<LocalException>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
