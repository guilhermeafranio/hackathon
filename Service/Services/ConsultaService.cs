using Domain.DTOs.Saida;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Service.Services;

public class ConsultaService(
    IConsultaRepository consultaRepository,
    IHorarioRepository horarioRepository) : IConsultaService
{
    private readonly IConsultaRepository _consultaRepository = consultaRepository;
    private readonly IHorarioRepository _horarioRepository = horarioRepository;

    public async Task<RespostaPadrao> AgendarConsulta(Consulta consulta)
    {
        try
        {
            var novoContato = await _consultaRepository.AgendarConsulta(consulta);
            return new RespostaPadrao(true, novoContato, "Consulta agendada com sucesso");
        }
        catch (Exception ex)
        {
            return new RespostaPadrao(false, null, ex.Message);
        }
    }

    public async Task<RespostaPadrao> CancelarConsultaPaciente(Guid idConsulta, string justificativa)
    {
        try
        {
            await _consultaRepository.CancelarConsultaPaciente(idConsulta, justificativa);
            return new RespostaPadrao(true, null, "Consulta foi cancelada mediante justificativa");
        }
        catch (Exception ex)
        {
            return new RespostaPadrao(false, null, ex.Message);
        }
    }

    public async Task<RespostaPadrao> AceitarConsultaMedico(Guid idConsulta)
    {
        try
        {
            await _consultaRepository.AceitarConsultaMedico(idConsulta);
            return new RespostaPadrao(true, null, "Consulta foi aceita pelo médico");
        }
        catch (Exception ex)
        {
            return new RespostaPadrao(false, null, ex.Message);
        }
    }

    public async Task<RespostaPadrao> CancelarConsultaMedico(Guid idConsulta)
    {
        try
        {
            await _consultaRepository.CancelarConsultaMedico(idConsulta);
            return new RespostaPadrao(true, null, "Consulta foi cancelada pelo médico");
        }
        catch (Exception ex)
        {
            return new RespostaPadrao(false, null, ex.Message);
        }
    }

    public async Task<RespostaPadrao> ListarMedicosPorEspecialidade(int especialidade)
    {
        try
        {
            var listaUsuarios = await _consultaRepository.ListarMedicosPorEspecialidade(especialidade);
            var listaRetorno = new List<MedicoDTO>();

            foreach (var usuario in listaUsuarios)
                listaRetorno.Add(MedicoDTO.ConverterParaMedicoDTO(usuario));

            return new RespostaPadrao(true, listaRetorno, null);
        }
        catch (Exception ex)
        {
            return new RespostaPadrao(false, null, ex.Message);
        }
    }

    public async Task<RespostaPadrao> ConsultarAgendaMedico(string crm)
    {
        try
        {
            var medico = await _consultaRepository.ObterMedico(crm);

            if (medico == null)
                return new RespostaPadrao(false, null, "Médico não encontrado.");

            var horarios = await _horarioRepository.ListarHorariosPorMedico(medico.Id);

            return new RespostaPadrao(
                true, 
                AgendaMedicoDTO.ConverterAgendaMedicoDTO(medico, horarios), 
                null);
        }
        catch (Exception ex)
        {
            return new RespostaPadrao(false, null, ex.Message);
        }
    }
}
