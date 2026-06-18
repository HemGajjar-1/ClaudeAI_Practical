using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Application.Interfaces;
using StudentManagement.Infrastructure.Persistence;
using StudentManagement.Infrastructure.UnitOfWorkLayer;

namespace StudentManagement.Infrastructure.DependencyInjection;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<InMemoryDatabase>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
