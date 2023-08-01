using Articles.Application.Dtos;
using Articles.Application.Features.Article.Create;
using Articles.Application.Mappings;
using Articles.Core.EF;
using Articles.Core.JWT;
using Articles.Domain.Repositories;
using Articles.Infra.EF.Contexts;
using Articles.Infra.EF.Identity;
using Articles.Infra.EF.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Net6._0Api.Attributes;
using Net6._0Api.Exceptions;
using Net6._0Api.MiddlewareRegisteration;
using Net6._0Api.ServiceRegisteration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( opt =>
{
  //opt.Filters.Add(new PermissionFilterAttribute());
  // bütün uygulama genelinde istekler filtrelenmiþ oluyorç
}).AddFluentValidation(opt =>
{
  opt.RegisterValidatorsFromAssemblyContaining<ArticleCreateValidator>();
});


builder.Services.RegisterApiServices(builder.Configuration);
builder.Services.RegisterApplicationService();
builder.Services.RegisterInfraServices(builder.Configuration);


// middlewares
var app = builder.Build();



app.UseCustomException();

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
