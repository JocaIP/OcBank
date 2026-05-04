using OcBank.Domain.Entities;

public interface IUsuarioRepositorio
{
    Task CriarAsync(Usuario usuario);
    Task<List<Usuario>> ObterTodosAsync();
    Task<Usuario?> ObterPorEmailAsync(string email);
}