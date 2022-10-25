using ApiColegio;
using ApiColegio.Context;
using ApiColegio.Queries.StudentQueries;
using Microsoft.EntityFrameworkCore;
using ServiceStack;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var configuration= provider.GetService<IConfiguration>();
var services = builder.Services;
// Add services to the container.

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<ConexionSQLServer>(options => options
.UseSqlServer(configuration
.GetConnectionString("CadenaConexionSQLServer")));

services.AddScoped<StudentQuery>();

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
