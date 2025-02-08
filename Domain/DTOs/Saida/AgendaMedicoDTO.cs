using Domain.Models;

namespace Domain.DTOs.Saida;

public class AgendaMedicoDTO
{
    public string CRM { get; set; }
    public string NomeCompleto { get; set; }
    public int Especialidade { get; set; }
    public double ValorConsulta { get; set; }
    public List<Horario> Horarios { get; set; } = [];

    public static AgendaMedicoDTO ConverterAgendaMedicoDTO(Usuario usuario, List<Horario> horarios)
    {
        return new AgendaMedicoDTO
        {
            CRM = usuario.CRM,
            Especialidade = usuario.Especialidade.GetValueOrDefault(),
            NomeCompleto = usuario.FullName,
            ValorConsulta = usuario.ValorConsulta,
            Horarios = horarios
        };
    }
}
