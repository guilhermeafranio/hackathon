using Domain.DTOs.Saida;
using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IHorarioRepository
{
    Task<Horario> CriarHorario(Horario horario);
    Task<Horario> AtualizarHorario(Horario horario);
    Task<bool> ExcluirHorario(Guid id);
    Task<List<Horario>> ListarHorariosPorMedico(string idMedico);
}