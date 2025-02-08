using Domain.DTOs.Saida;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class HoararioController(IHorarioService contatoService) : Controller
{
    private readonly IHorarioService _horarioService = contatoService;

    [HttpPost]
    public async Task<IActionResult> CriarHoario([FromBody] Horario horario)
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
    public async Task<IActionResult> AtualizarContato([FromBody] Horario horario)
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

    [HttpDelete("{id}")]
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

    [HttpGet("idMedico/{idMedico}")]
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