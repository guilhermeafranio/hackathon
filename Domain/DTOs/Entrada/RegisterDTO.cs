﻿namespace Domain.DTOs.Entrada;

public class RegisterDTO
{
    public string? CRM { get; set; }
    public string? Email { get; set; }
    public string FullName { get; set; }
    public string? Especialidade { get; set; }
    public string? ValorConsulta { get; set; }
    public string Password { get; set; }
}
