using Domain.DTOs.Saida;
using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IHorarioService
{
    Task<RespostaPadrao> CriarHorario(Horario horario);
    Task<RespostaPadrao> AtualizarHorario(Horario horario);
    Task<RespostaPadrao> ExcluirHorario(Guid id);
    Task<RespostaPadrao> ListarHorariosPorMedico(string idMedico);
}