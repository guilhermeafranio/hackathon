﻿using Microsoft.AspNetCore.Identity;

namespace Domain.Models;

public class Usuario : IdentityUser
{
    public string? FullName { get; set; }
    public string? CRM { get; set; }
    public string? Especialidade { get; set; }
    public string? ValorConsulta { get; set; }
}
