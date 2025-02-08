using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace CrossCutting.Dependencies;

public class ConfigureService
{
    public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IHorarioService, HorarioService>();
        serviceCollection.AddTransient<IConsultaService, ConsultaService>();

        serviceCollection.AddTransient<IHorarioRepository, HorarioRepository>();
        serviceCollection.AddTransient<IConsultaRepository, ConsultaRepository>();
    }
}