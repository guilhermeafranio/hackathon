using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Horario
{
    [Key]
    public Guid Id { get; set; }

    public DateTime Dia { get; set; }

    public TimeSpan Hora {  get; set; }

    public string IdUsuario { get; set; }
    
    [ForeignKey("IdUsuario")]
    public Usuario? Medico { get; set; }
}
