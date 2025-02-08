using Domain.Models;

namespace Domain.DTOs.Saida;

public class MedicoDTO
{
    public string CRM { get; set; }
    public string NomeCompleto { get; set; }
    public int Especialidade { get; set; }

    public static MedicoDTO ConverterParaMedicoDTO(Usuario usuario)
    {
        return new MedicoDTO
        {
            CRM = usuario.CRM,
            Especialidade = usuario.Especialidade.GetValueOrDefault(),
            NomeCompleto = usuario.FullName
        };
    }
}
