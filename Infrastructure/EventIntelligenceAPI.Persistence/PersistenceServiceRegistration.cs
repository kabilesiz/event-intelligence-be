using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using EventIntelligenceAPI.Persistence.Contexts;
using EventIntelligenceAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EventIntelligenceAPI.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<EventIntelligenceApiDbContext>(opt =>
        {
            opt.UseSqlite(ConnectionStringConfiguration.GetSqLiteConnectionString())
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
        services.AddScoped<IGenericRepository<Role>, GenericRepository<Role,EventIntelligenceApiDbContext>>();
        return services;
    }
}