using OcBank.Domain.Entities;

namespace OcBank.Application.UseCases.ObterUsuarios;

public class ObterUsuariosUseCase
{
    private readonly IUsuarioRepositorio _repositorio;

    public ObterUsuariosUseCase(IUsuarioRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<Usuario>> Executar()
    {
        return await _repositorio.ObterTodosAsync();
    }
}