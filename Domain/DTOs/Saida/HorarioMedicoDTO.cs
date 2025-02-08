using Domain.Models;

namespace Domain.DTOs.Saida;

public class HorarioMedicoDTO
{
    public string CRM { get; set; }
    public string NomeCompleto { get; set; }
    public int Especialidade { get; set; }
    public string ValorConsulta { get; set; }
    public List<Horario> Horarios { get; set; } = [];

    public static HorarioMedicoDTO ConverterHorarioMedicoDTO(Usuario usuario, List<Horario> horarios)
    {
        return new HorarioMedicoDTO
        {
            CRM = usuario.CRM,
            Especialidade = Convert.ToInt32(usuario.Especialidade),
            NomeCompleto = usuario.FullName,
            ValorConsulta = usuario.ValorConsulta,
            Horarios = horarios
        };
    }
}
