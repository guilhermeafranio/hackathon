using CrossCutting.Dependencies;
using MassTransit;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

ConfigureRepository.ConfigureDependenciesRepository(builder.Services, builder.Configuration);
ConfigureService.ConfigureDependenciesService(builder.Services);

var configuration = builder.Configuration;
var servidor = configuration.GetSection("MassTransit")["Servidor"] ?? string.Empty;
var usuario = configuration.GetSection("MassTransit")["Usuario"] ?? string.Empty;
var senha = configuration.GetSection("MassTransit")["Senha"] ?? string.Empty;

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(servidor, "/", h =>
        {
            h.Username(usuario);
            h.Password(senha);
        });

        cfg.ConfigureEndpoints(context);
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseHttpsRedirection();

app.Run();

public partial class Program { }
