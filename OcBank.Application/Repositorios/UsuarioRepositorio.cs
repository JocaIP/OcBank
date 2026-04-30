using OcBank.Domain.Entities;

namespace OcBank.Application.Repositorios;

public class UsuarioRepositorio
{
    private static List<Usuario> _usuarios = new();

    public void Adicionar(Usuario usuario)
    {
        _usuarios.Add(usuario);
    }

    public List<Usuario> ObterTodos()
    {
        return _usuarios;
    }
}