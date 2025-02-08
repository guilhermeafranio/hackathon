using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Consulta
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Informe o status da consulta")]
    public int Status { get; set; }

    public string? JustificativaCancelamento { get; set; }

    [Required(ErrorMessage = "Informe o horário")]
    public Guid IdHorario { get; set; }
    
    [ForeignKey("IdHorario")]
    public Horario? Horario { get; set; }
}
