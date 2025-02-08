using Microsoft.AspNetCore.Identity;

namespace Domain.Models;

public class Usuario : IdentityUser
{
    public string? FullName { get; set; }
    public string? CRM { get; set; }
    public int? Especialidade { get; set; }
    public double ValorConsulta { get; set; }
}
