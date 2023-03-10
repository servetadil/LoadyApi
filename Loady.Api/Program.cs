using FluentValidation;
using Loady.Api.Application.Model;
using Loady.Api.Application.Services;
using Loady.Api.Core.Repository;
using Loady.Api.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using System;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables()
              .Build();
builder.Services.AddSingleton<IConfiguration>(config);

var connectionString= builder.Configuration.GetValue<string>("MongoDbSettings:ConnectionString");

MongoClientSettings mongoDbsettings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
builder.Services.AddSingleton((s) => new MongoClient(mongoDbsettings));
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IDriverService, DriverService>();
builder.Services.AddScoped<IValidator<GetByCityQueryModel>, GetByCityQueryModelValidator>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// error handling middleware
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
