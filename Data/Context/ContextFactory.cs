using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Data.Context;

public class ContextFactory : IDesignTimeDbContextFactory<HackathonContext>
{
  
    public HackathonContext CreateDbContext(string[] args)
    {
        var ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        
        var file = Path.Combine("..", "Application", $"appsettings.{ambiente}.json");
        Console.WriteLine(file);
        var jsonString = File.ReadAllText(file);
        var json = JsonConvert.DeserializeObject<dynamic>(jsonString);
        string connectionString = json!["ConnectionStrings"]["Hackathon"];
        var optionsBuilder = new DbContextOptionsBuilder<HackathonContext>();

        optionsBuilder.UseNpgsql(connectionString);
        return new HackathonContext(optionsBuilder.Options);
    }
}