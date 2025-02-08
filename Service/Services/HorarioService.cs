using Domain.DTOs.Saida;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Service.Services;

public class HorarioService(
    IHorarioRepository horarioRepository) : IHorarioService
{
    private readonly IHorarioRepository _horarioRepository = horarioRepository;

    public async Task<RespostaPadrao> CriarHorario(Horario horario)
    {
        try
        {
            var novoHorario = await _horarioRepository.CriarHorario(horario);
            return new RespostaPadrao(true, novoHorario, "Horário criado com sucesso");
        }
        catch (Exception ex)
        {
            return new RespostaPadrao(false, null, ex.Message);
        }
    }

    public async Task<RespostaPadrao> AtualizarHorario(Horario horario)
    {
        try
        {
            var horarioAtualizado = await _horarioRepository.AtualizarHorario(horario);
            if (horarioAtualizado.Id == Guid.Empty)
                return new RespostaPadrao(true, null, "Horário não encontrado");
            
            return new RespostaPadrao(true, horarioAtualizado, "Horário atualizado com sucesso");
        }
        catch (Exception ex)
        {
            return new RespostaPadrao(false, null, ex.Message);
        }
    }

    public async Task<RespostaPadrao> ExcluirHorario(Guid id)
    {
        try
        {
            var horarioExcluido = await _horarioRepository.ExcluirHorario(id);
            if (!horarioExcluido)
            {
                return new RespostaPadrao(true, horarioExcluido, "Horário não encontrado");
            }
            return new RespostaPadrao(true, horarioExcluido, "Horário excluido com sucesso");
        }
        catch (Exception ex)
        {
            return new RespostaPadrao(false, null, ex.Message);
        }
    }

    public async Task<RespostaPadrao> ListarHorariosPorMedico(string idMedico)
    {
        try
        {
            var listaHorarios = await _horarioRepository.ListarHorariosPorMedico(idMedico);
            return new RespostaPadrao(true, listaHorarios, null);
        }
        catch (Exception ex)
        {
            return new RespostaPadrao(false, null, ex.Message);
        }
    }
}