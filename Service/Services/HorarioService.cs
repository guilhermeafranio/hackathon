using Domain.DTOs.Saida;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Service.Services;

public class HorarioService(IHorarioRepository contatoRepository) : IHorarioService
{
    private readonly IHorarioRepository _contatoRepository = contatoRepository;

    public async Task<RespostaPadrao> CriarHorario(Horario horario)
    {
        try
        {
            var novoHorario = await _contatoRepository.CriarHorario(horario);
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
            var contatoAtualizado = await _contatoRepository.AtualizarHorario(horario);
            if (contatoAtualizado.Id == Guid.Empty)
                return new RespostaPadrao(true, null, "Horário não encontrado");
            
            return new RespostaPadrao(true, contatoAtualizado, "Horário atualizado com sucesso");
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
            var contatoExcluido = await _contatoRepository.ExcluirHorario(id);
            if (!contatoExcluido)
            {
                return new RespostaPadrao(true, contatoExcluido, "Horário não encontrado");
            }
            return new RespostaPadrao(true, contatoExcluido, "Horário excluido com sucesso");
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
            var listaContatos = await _contatoRepository.ListarHorariosPorMedico(idMedico);
            return new RespostaPadrao(true, listaContatos, null);
        }
        catch (Exception ex)
        {
            return new RespostaPadrao(false, null, ex.Message);
        }
    }
}