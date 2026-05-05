using Microsoft.AspNetCore.Mvc;
using OcBank.Application.UseCases.CriarUsuario;
using OcBank.Application.UseCases.Extrato;
using OcBank.Application.UseCases.ObterUsuarios;
using OcBank.Application.UseCases.Sacar;
using OcBank.Application.UseCases.Saldo;
using OcBank.Application.UseCases.Transferir;

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

    [HttpGet("Saldo/{contaId}")]
    public async Task<IActionResult> ObterSaldo(
       [FromServices] ObterSaldoUseCase useCase, Guid contaId)
    {
        try
        {
            var saldo = await useCase.Executar(contaId);
            return Ok(new { saldo });
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });

        }
    }

    [HttpPost("saque")]
    public async Task<IActionResult> Sacar(
        [FromServices] SacarUseCase useCase, [FromBody] SacarInput input)
    {
        try
        {
            await useCase.Executar(input);
            return Ok("Saque realizado com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [HttpPost("transferencia")]
    public async Task<IActionResult> Transferir(
    [FromServices] TransferirUseCase useCase,
    [FromBody] TransferirInput input)
    {
        try
        {
            await useCase.Executar(input);
            return Ok("Transferência realizada com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [HttpGet("extrato/{contaId}")]
    public async Task<IActionResult> Extrato(
    [FromServices] ObterExtratoUseCase useCase,
    Guid contaId)
    {
        var extrato = await useCase.Executar(contaId);
        return Ok(extrato);
    }
}