using Microsoft.Extensions.Configuration;

namespace EventIntelligenceAPI.Persistence;

static class ConnectionStringConfiguration
{
    public static string GetSqLiteConnectionString()
    {
        ConfigurationManager configurationManager = new();
        configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/EventIntelligenceAPI.API"));
        configurationManager.AddJsonFile("appsettings.json");

        return configurationManager.GetConnectionString("SqLite");
    }
}