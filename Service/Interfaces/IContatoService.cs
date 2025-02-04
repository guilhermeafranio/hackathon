using Domain.DTOs.Saida;
using Domain.Models;

namespace Service.Interfaces;

public interface IContatoService
{
    Task<RespostaPadrao> CriarContato(Contato contato);
    Task<RespostaPadrao> ListarContatosDdd(string ddd);
    Task<RespostaPadrao> AtualizarContato(Contato contato);
    Task<RespostaPadrao> ExcluirContato(int id);
}