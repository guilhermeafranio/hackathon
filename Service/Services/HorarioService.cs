using Domain.DTOs.Entrada;
using Domain.DTOs.Saida;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Service.Services;

public class HorarioService(
    IHorarioRepository horarioRepository) : IHorarioService
{
    private readonly IHorarioRepository _horarioRepository = horarioRepository;

    public async Task<RespostaPadrao> CriarHorario(HorarioDTO horario)
    {
        try
        {
            var model = new Horario
            {
                Id = Guid.NewGuid(),
                Dia = horario.Dia,
                Hora = horario.Hora,
                IdUsuario = horario.IdUsuario
            };

            var novoHorario = await _horarioRepository.CriarHorario(model);
            return new RespostaPadrao(true, novoHorario, "Horário criado com sucesso");
        }
        catch (Exception ex)
        {
            return new RespostaPadrao(false, null, ex.Message);
        }
    }

    public async Task<RespostaPadrao> AtualizarHorario(HorarioDTO horario)
    {
        try
        {
            var model = new Horario
            {
                Id = horario.Id,
                Dia = horario.Dia,
                Hora = horario.Hora,
                IdUsuario = horario.IdUsuario
            };

            var horarioAtualizado = await _horarioRepository.AtualizarHorario(model);
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