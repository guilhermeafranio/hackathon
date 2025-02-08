using Domain.DTOs.Entrada;
using Domain.DTOs.Saida;
using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IHorarioService
{
    Task<RespostaPadrao> CriarHorario(HorarioDTO horario);
    Task<RespostaPadrao> AtualizarHorario(HorarioDTO horario);
    Task<RespostaPadrao> ExcluirHorario(Guid id);
    Task<RespostaPadrao> ListarHorariosPorMedico(string crm);
}