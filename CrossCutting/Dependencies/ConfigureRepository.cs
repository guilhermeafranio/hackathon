using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.Dependencies;

public class ConfigureRepository
{
    public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<HackathonContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("Hackathon"))
        );
    }
}