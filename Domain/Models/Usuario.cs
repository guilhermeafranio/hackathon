namespace Domain.Models;
using Microsoft.AspNetCore.Identity;

public class Usuario : IdentityUser
{
    public string FullName { get; set; }
    public string CRM { get; set; }
}
