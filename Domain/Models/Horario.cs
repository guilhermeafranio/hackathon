using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Horario
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Informe o dia")]
    public DateTime Dia { get; set; }
    [Required(ErrorMessage = "Informe a hora")]
    public TimeSpan Hora {  get; set; }

    [Required(ErrorMessage = "Informe o médico")]
    public string IdUsuario { get; set; }
    
    [ForeignKey("IdUsuario")]
    public Usuario? Medico { get; set; }
}
