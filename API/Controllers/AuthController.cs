using Domain.DTOs.Entrada;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(
    UserManager<Usuario> userManager,
    RoleManager<IdentityRole> roleManager,
    IConfiguration configuration) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO model)
    {
        var usuario = new Usuario
        {
            FullName = model.FullName,
            CRM = model.CRM,
            Email = model.Email,
            Especialidade = model.Especialidade,
            ValorConsulta = model.ValorConsulta
        };

        string role;
        if (!string.IsNullOrEmpty(model.CRM))
        {
            usuario.UserName = model.CRM;
            role = "Medico";
        }
        else
        {
            usuario.UserName = model.Email;
            role = "Paciente";
        }

        var result = await userManager.CreateAsync(usuario, model.Password);
        if (!result.Succeeded) return BadRequest(result.Errors);

        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));

        await userManager.AddToRoleAsync(usuario, role);

        return Ok(new { message = "Usuário cadastrado com sucesso!", role, id = usuario.Id });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO model)
    {
        Usuario usuario;
        if (model.CRM != null)
            usuario = await userManager.FindByNameAsync(model.CRM);
        else
            usuario = await userManager.FindByEmailAsync(model.Email);

        if (usuario == null || !await userManager.CheckPasswordAsync(usuario, model.Password))
            return Unauthorized("Credenciais inválidas!");

        var token = await GenerateJwtToken(usuario);
        return Ok(new { id = usuario.Id, token });
    }

    private async Task<string> GenerateJwtToken(Usuario user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var userRoles = await userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("FullName", user.FullName != null ? user.FullName : ""),
            new Claim("CRM", user.CRM != null ? user.CRM : ""),
            new Claim("Especialidade", user.Especialidade != null ? user.Especialidade : ""),
            new Claim("ValorConsulta", user.ValorConsulta != null ? user.ValorConsulta : ""),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
