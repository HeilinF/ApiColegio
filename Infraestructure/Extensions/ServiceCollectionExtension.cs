
using Domain.Interface.Repository.Common;
using Infraestructure.Repository.StudentRepository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ApiColegio;

public static class ServiceCollectionExtension
{
   public static void AddRepositories(this IServiceCollection services)
    {
      services.AddTransient<IStudentRepository, StudentRepository>();

    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        return services.AddMediatR(assembly);
    }
}
