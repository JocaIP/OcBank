using Microsoft.AspNetCore.Mvc;
using OcBank.Application.UseCases.CriarUsuario;
using OcBank.Application.UseCases.ObterUsuarios;

namespace OcBank.Api.Controllers;

[ApiController]
[Route("usuarios")]
public class UsuariosController : ControllerBase
{
    private readonly CriarUsuarioUseCase _useCase;

    public UsuariosController(CriarUsuarioUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(CriarUsuarioInput input)
    {
        try
        {
            var resultado = await _useCase.Executar(input);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
    [HttpGet]
    public async Task<IActionResult> ObterTodos([FromServices] ObterUsuariosUseCase useCase)
    {
        var usuarios = await useCase.Executar();

        var resultado = usuarios.Select(u => new
        {
            u.Id,
            u.Nome,
            u.Email
        });

        return Ok(resultado);
    }
}