using ApiColegio;
using ApiColegio.Contexts;
using Microsoft.EntityFrameworkCore;
using ServiceStack;


// private static IConfiguration Configuration { get; }

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var configuration= provider.GetService<IConfiguration>();
var services = builder.Services;
// Add services to the container.
services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddDbContext<ConexionSQLServer>(options => options.UseSqlServer(configuration.GetConnectionString("CadenaConexionSQLServer")));
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
