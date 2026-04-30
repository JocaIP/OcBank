using OcBank.Application.Repositorios;
using OcBank.Domain.Entities;

namespace OcBank.Application.UseCases.CriarUsuario;

public class CriarUsuarioUseCase
{
    private readonly UsuarioRepositorio _repositorio;

    public CriarUsuarioUseCase(UsuarioRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public CriarUsuarioOutput Executar(CriarUsuarioInput input)
    {
        if (string.IsNullOrWhiteSpace(input.Nome) ||
            string.IsNullOrWhiteSpace(input.Email))
        {
            throw new Exception("Nome e Email são obrigatórios");
        }

        var usuario = new Usuario(input.Nome, input.Email);
        var conta = new Conta(usuario.Id);

        _repositorio.Adicionar(usuario);

        return new CriarUsuarioOutput
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email
        };
    }
}