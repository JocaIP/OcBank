using Microsoft.AspNetCore.Mvc;
using OcBank.Application.Repositorios;
using OcBank.Application.UseCases.CriarUsuario;

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
    public IActionResult Criar([FromBody] CriarUsuarioInput input)
    {
        try
        {
            var resultado = _useCase.Executar(input);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [HttpGet]
    public IActionResult ObterTodos([FromServices] UsuarioRepositorio repositorio)
    {
        var usuarios = repositorio.ObterTodos();

        var resultado = usuarios.Select(u => new
        {
            u.Id,
            u.Nome,
            u.Email
        });

        return Ok(resultado);
    }
}