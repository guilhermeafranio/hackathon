using Data.Context;
using Domain.DTOs.Saida;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ConsultaRepository(HackathonContext context) : IConsultaRepository
{
    private readonly HackathonContext _context = context;
    public async Task<Consulta> AgendarConsulta(Consulta consulta)
    {
        try
        {
            consulta.Status = (int)StatusConsultaEnum.AgendadoPaciente;

            await _context.Consulta.AddAsync(consulta);
            await _context.SaveChangesAsync();

            return consulta;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao agendar consulta", ex);
        }
    }

    public async Task AceitarConsultaMedico(Guid idConsulta)
    {
        try
        {
            await _context.Consulta.Where(x => x.Id == idConsulta)
            .ExecuteUpdateAsync(setters => setters.SetProperty
                                    (s => s.Status, (int)StatusConsultaEnum.AceitoMedico));
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao aceitar consulta", ex);
        }
    }

    public async Task CancelarConsultaMedico(Guid idConsulta)
    {
        try
        {
            await _context.Consulta.Where(x => x.Id == idConsulta)
            .ExecuteUpdateAsync(setters => setters.SetProperty
                                    (s => s.Status, (int)StatusConsultaEnum.CanceladoMedico));
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao cancelar consulta pelo médico", ex);
        }
    }

    public async Task CancelarConsultaPaciente(Guid idConsulta, string justificativa)
    {
        try
        {
            await _context.Consulta.Where(x => x.Id == idConsulta)
            .ExecuteUpdateAsync(setters => setters
                    .SetProperty(s => s.Status, (int)StatusConsultaEnum.CanceladoPaciente)
                    .SetProperty(s => s.JustificativaCancelamento, justificativa));
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao cancelar consulta pelo paciente", ex);
        }
    }

    public async Task<List<Usuario>> ListarMedicosPorEspecialidade(int especialidade)
    {
        try
        {
            return await _context.Users
                .Where(w => w.Especialidade == especialidade.ToString())
                .AsNoTracking()
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao obter horarios por médico", ex);
        }
    }

    public async Task<Usuario?> ObterMedico(string crm)
    {
        try
        {
            return await _context.Set<Usuario>()
                .Where(x => x.UserName == crm).FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao consultar o médico", ex);
        }
    }

    public async Task<List<Consulta>> ListarConsultasPorPaciente(string email)
    {
        return await _context.Consulta
            .Include(x => x.Horario)
            .Include(x => x.Paciente)
            .Where(x => x.Paciente.Email == email)
            .ToListAsync();
    }

    public async Task<List<Consulta>> ListarConsultasPorMedico(string crm)
    {
        return await _context.Consulta
            .Include(x => x.Horario)
            .ThenInclude(x => x.Medico)
            .Where(x => x.Horario.Medico.CRM == crm)
            .ToListAsync();
    }
}
