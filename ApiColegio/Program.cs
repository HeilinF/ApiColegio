using ApiColegio;
using ApiColegio.Requests.StudentRequest;
using ApiColegio.Requests.SubjectRequest;
using ApiColegio.Requests.TeacherRequest;
using Domain.Context;
using Domain.Entities.Models;
using Domain.Interface.Repository.Common;
using Infraestructure.Repository.StudentRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var builder = WebApplication.CreateBuilder(args);
//var provider = builder.Services.BuildServiceProvider();
//var configuration= provider.GetService<IConfiguration>();
var services = builder.Services;
// Add services to the container.

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddAutoMapper(Assembly.GetExecutingAssembly());

services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

services.AddDbContext<ConexionSQLServer>(options => options
.UseSqlServer(builder.Configuration
.GetConnectionString("CadenaConexionSQLServer"), b => b.MigrationsAssembly("ApiColegio")));

// Use DI to inyect the Services that you need 
services.AddScoped<StudentRequest>();
services.AddScoped<TeacherRequest>();
services.AddScoped<SubjectRequest>();

services.AddRepositories();
//services.AddApplication();
//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
