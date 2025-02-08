using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Entrada;

public class HorarioDTO
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Informe o dia")]
    public DateTime Dia { get; set; }

    [Required(ErrorMessage = "Informe a hora")]
    public TimeSpan Hora { get; set; }

    [Required(ErrorMessage = "Informe o id do médico")]
    public string IdUsuario { get; set; }
}
