using EventIntelligenceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EventIntelligenceAPI.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EventIntelligenceApiDbContext>
{
    public EventIntelligenceApiDbContext CreateDbContext(string[] args)
    {
        
        DbContextOptionsBuilder<EventIntelligenceApiDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseSqlite(ConnectionStringConfiguration.GetSqLiteConnectionString());
        return new (dbContextOptionsBuilder.Options);
    }
}