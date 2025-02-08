using Domain.DTOs.Entrada;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Medico")]
public class HorarioController(IHorarioService horarioService) : ControllerBase
{
    private readonly IHorarioService _horarioService = horarioService;
    
    [HttpPost]
    [Route("CriarHorario")]
    public async Task<IActionResult> CriarHorario([FromBody] HorarioDTO horario)
    {
        if (ModelState.IsValid)
        {
            try
            {
                return Ok(await _horarioService.CriarHorario(horario));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        return BadRequest();
    }

    [HttpPut]
    [Route("AtualizarHorario")]
    public async Task<IActionResult> AtualizarHorario([FromBody] HorarioDTO horario)
    {
        if (ModelState.IsValid)
        {
            try
            {
                return Ok(await _horarioService.AtualizarHorario(horario));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        return BadRequest(500);
    }

    [HttpDelete("ExcluirHorario/{id}")]
    public async Task<IActionResult> ExcluirHorario(Guid id)
    {
        try
        {
            return Ok(await _horarioService.ExcluirHorario(id));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("ListarHorariosPorMedico/{idMedico}")]
    public async Task<IActionResult> ListarHorariosPorMedico(string idMedico)
    {
        var listaHorarios = await _horarioService.ListarHorariosPorMedico(idMedico);
        if (listaHorarios.Sucesso)
        {
            return Ok(listaHorarios);
        }

        return StatusCode(500, listaHorarios);
    }
}