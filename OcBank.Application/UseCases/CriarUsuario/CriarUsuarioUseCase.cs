using OcBank.Application.Repositories;
using OcBank.Domain.Entities;

namespace OcBank.Application.UseCases.CriarUsuario;

public class CriarUsuarioUseCase
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly IContaRepositorio _contaRepositorio;

    public CriarUsuarioUseCase(
        IUsuarioRepositorio usuarioRepositorio,
        IContaRepositorio contaRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
        _contaRepositorio = contaRepositorio;
    }

    public async Task<CriarUsuarioOutput> Executar(CriarUsuarioInput input)
    {
        if (string.IsNullOrWhiteSpace(input.Nome) ||
            string.IsNullOrWhiteSpace(input.Email))
        {
            throw new Exception("Nome e Email são obrigatórios");
        }

        var usuarioExistente = await _usuarioRepositorio.ObterPorEmailAsync(input.Email);

        if (usuarioExistente != null)
        {
            throw new Exception("Email já está em uso");
        }

        var usuario = new Usuario(input.Nome, input.Email);
        var conta = new Conta(usuario.Id);

        // 🔥 salva os dois
        await _usuarioRepositorio.CriarAsync(usuario);
        await _contaRepositorio.CriarAsync(conta);

        return new CriarUsuarioOutput
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email
        };
    }
}