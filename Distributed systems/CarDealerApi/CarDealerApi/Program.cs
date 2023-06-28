using AutoMapper;
using CarDealerApi.Data;
using CarDealerApi.Dto;
using CarDealerApi.Interface;
using CarDealerApi.Models;
using CarDealerApi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("Connection"));
});
builder.Services.AddScoped<UserInterface,UserRepository>();
builder.Services.AddScoped<CarInterface,CarRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
