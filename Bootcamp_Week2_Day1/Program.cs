using Bootcamp_Week2_Day1.Filter;
using Bootcamp_Week2_Day1.Manager;
using Bootcamp_Week2_Day1.Repository;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// FluentValidation Dependency Injection 
builder.Services.AddControllers(option =>option.Filters.Add(new ValidateFilter()))
    .AddFluentValidation(x=>x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));


// Send Custom Error Messages
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter= true;
});
//.Net Core Base Dependency Injection
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ProductService>();

builder.Services.AddScoped<NotFoundProductFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
