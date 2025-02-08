using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Entrada;

public class ConsultaDTO
{
    [Required(ErrorMessage = "Informe o email do Paciente")]
    public string EmailPaciente { get; set; }

    [Required(ErrorMessage = "Informe o horário da consulta")]
    public Guid IdHorario { get; set; }
}
