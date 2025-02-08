using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsultaController(IConsultaService consultaService) : ControllerBase
{
    private readonly IConsultaService _consultaService = consultaService;

    [HttpPost]
    public async Task<IActionResult> AgendarConsulta([FromBody] Consulta consulta)
    {
        if (ModelState.IsValid)
        {
            try
            {
                return Ok(await _consultaService.AgendarConsulta(consulta));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        return BadRequest();
    }

    [HttpPut]
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

    [HttpPut]
    [Route("AceitarConsultaMedico")]
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

    [HttpPut]
    [Route("CancelarConsultaMedico")]
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

    [HttpGet("especialidade/{especialidade}")]
    public async Task<IActionResult> ListarMedicosPorEspecialidade(int especialidade)
    {
        var listaHorarios = await _consultaService.ListarMedicosPorEspecialidade(especialidade);

        if (listaHorarios.Sucesso)
            return Ok(listaHorarios);

        return StatusCode(500, listaHorarios);
    }

    [HttpGet("crm/{crm}")]
    public async Task<IActionResult> ConsultarAgendaMedico(string crm)
    {
        var listaAgenda = await _consultaService.ConsultarAgendaMedico(crm);

        if (listaAgenda.Sucesso)
            return Ok(listaAgenda);

        return StatusCode(500, listaAgenda);
    }
}
