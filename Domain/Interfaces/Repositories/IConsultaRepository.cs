using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IConsultaRepository
{
    Task<Consulta> AgendarConsulta(Consulta consulta);
    Task CancelarConsultaPaciente(Guid idConsulta, string justificativa);
    Task AceitarConsultaMedico(Guid idConsulta);
    Task CancelarConsultaMedico(Guid idConsulta);
    Task<List<Usuario>> ListarMedicosPorEspecialidade(int especialidade);
    Task<Usuario?> ObterMedico(string crm);
}