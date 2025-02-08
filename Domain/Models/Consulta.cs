using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Consulta
{
    [Key]
    public Guid Id { get; set; }

    public int Status { get; set; }

    public string? JustificativaCancelamento { get; set; }

    public string IdPaciente { get; set; }

    [ForeignKey("IdPaciente")]
    public Usuario? Paciente { get; set; }

    public Guid IdHorario { get; set; }
    
    [ForeignKey("IdHorario")]
    public Horario? Horario { get; set; }
}
