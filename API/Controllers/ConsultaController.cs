using Domain.DTOs.Entrada;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsultaController(
    IConsultaService consultaService,
    UserManager<Usuario> userManager) : ControllerBase
{
    private readonly IConsultaService _consultaService = consultaService;

    [HttpGet("ListarMedicosPorEspecialidade/{especialidade}")]
    [Authorize(Roles = "Paciente")]
    public async Task<IActionResult> ListarMedicosPorEspecialidade(int especialidade)
    {
        var listaHorarios = await _consultaService.ListarMedicosPorEspecialidade(especialidade);

        if (listaHorarios.Sucesso)
            return Ok(listaHorarios);

        return StatusCode(500, listaHorarios);
    }

    [HttpGet("ListarHorariosMedico/{crm}")]
    [Authorize(Roles = "Paciente")]
    public async Task<IActionResult> ListarHorariosMedico(string crm)
    {
        var listaHorarios = await _consultaService.ListarHorariosMedico(crm);

        if (listaHorarios.Sucesso)
            return Ok(listaHorarios);

        return StatusCode(500, listaHorarios);
    }

    [HttpPost("AgendarConsulta")]
    [Authorize(Roles = "Paciente")]
    public async Task<IActionResult> AgendarConsulta([FromBody] ConsultaDTO consulta)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var paciente = await userManager.FindByEmailAsync(consulta.EmailPaciente);

                if (paciente == null)
                    return BadRequest("Paciente não encontrado");

                return Ok(await _consultaService.AgendarConsulta(new Consulta
                {
                    Id = Guid.NewGuid(),
                    IdHorario = consulta.IdHorario,
                    IdPaciente = paciente.Id,
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        return BadRequest();
    }

    [HttpPost("ListarConsultasPorPaciente/{email}")]
    [Authorize(Roles = "Paciente")]
    public async Task<IActionResult> ListarConsultasPorPaciente(string email)
    {
        if (ModelState.IsValid)
        {
            try
            {
                return Ok(await _consultaService.ListarConsultasPorPaciente(email));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        return BadRequest();
    }


    [HttpPut("CancelarConsultaPaciente/{idConsulta}/{justificativa}")]
    [Authorize(Roles = "Paciente")]
    public async Task<IActionResult> CancelarConsultaPaciente(Guid idConsulta, string justificativa)
    {
        if (ModelState.IsValid)
        {
            try
            {
                return Ok(await _consultaService.CancelarConsultaPaciente(idConsulta, justificativa));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        return BadRequest();
    }

    [HttpPost("ListarConsultasPorMedico/{crm}")]
    [Authorize(Roles = "Medico")]
    public async Task<IActionResult> ListarConsultasPorMedico(string crm)
    {
        if (ModelState.IsValid)
        {
            try
            {
                return Ok(await _consultaService.ListarConsultasPorMedico(crm));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        return BadRequest();
    }

    [HttpPut("AceitarConsultaMedico/{idConsulta}")]
    [Authorize(Roles = "Medico")]
    public async Task<IActionResult> AceitarConsultaMedico(Guid idConsulta)
    {
        if (ModelState.IsValid)
        {
            try
            {
                return Ok(await _consultaService.AceitarConsultaMedico(idConsulta));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        return BadRequest();
    }

    [HttpPut("CancelarConsultaMedico/{idConsulta}")]
    [Authorize(Roles = "Medico")]
    public async Task<IActionResult> CancelarConsultaMedico(Guid idConsulta)
    {
        if (ModelState.IsValid)
        {
            try
            {
                return Ok(await _consultaService.CancelarConsultaMedico(idConsulta));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        return BadRequest();
    }
}
