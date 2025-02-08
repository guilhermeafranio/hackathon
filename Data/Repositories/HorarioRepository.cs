using Data.Context;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class HorarioRepository(HackathonContext context) : IHorarioRepository
{
    private readonly HackathonContext _context = context;

    public async Task<Horario> CriarHorario(Horario horario)
    {
        try
        {
            await _context.Horario.AddAsync(horario);
            await _context.SaveChangesAsync();

            return horario;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao adicionar novo horario", ex);
        }
    }

    public async Task<List<Horario>> ListarHorariosPorMedico(string idMedico)
    {
        try
        {
            var horarios = await _context.Horario
                .Where(w => w.IdUsuario == idMedico)
                .AsNoTracking()
                .ToListAsync();

            return horarios;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao obter horarios por médico", ex);
        }
    }

    public async Task<Horario> AtualizarHorario(Horario horario)
    {
        try
        {
            var horarioAntigo = await _context.Horario.FindAsync(horario.Id);
            if (horarioAntigo != null)
            {
                _context.Entry(horarioAntigo).CurrentValues.SetValues(horario);
                await _context.SaveChangesAsync();

                return horario;
            }

            return new Horario();
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao atualizar horario", ex);
        }
    }

    public async Task<bool> ExcluirHorario(Guid id)
    {
        try
        {
            var horario = await _context.Horario.SingleOrDefaultAsync(s => s.Id == id);
            if (horario == null)
            {
                return false;
            }

            _context.Horario.Remove(horario);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao excluir horario", ex);
        }
    }
}