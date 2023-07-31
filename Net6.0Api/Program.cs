using Articles.Application.Dtos;
using Articles.Application.Features.Article.Create;
using Articles.Core.EF;
using Articles.Domain.Repositories;
using Articles.Infra.EF.Contexts;
using Articles.Infra.EF.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Net6._0Api.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
  .AddFluentValidation(opt =>
{
  opt.RegisterValidatorsFromAssemblyContaining<ArticleCreateValidator>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<LocalException>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
