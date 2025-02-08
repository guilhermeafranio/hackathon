using Domain.DTOs.Saida;
using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IConsultaService
{
    Task<RespostaPadrao> AgendarConsulta(Consulta consulta);
    Task<RespostaPadrao> CancelarConsultaPaciente(Guid idConsulta, string justificativa);
    Task<RespostaPadrao> AceitarConsultaMedico(Guid idConsulta);
    Task<RespostaPadrao> CancelarConsultaMedico(Guid idConsulta);
    Task<RespostaPadrao> ListarMedicosPorEspecialidade(int especialidade);
    Task<RespostaPadrao> ConsultarAgendaMedico(string crm);
}