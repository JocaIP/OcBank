namespace OcBank.Domain.Entities;

public class Usuario
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public DateTime CriadoEm { get; private set; }
    public string SenhaHash { get; private set; }

    public Usuario(string nome, string email, string senha)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        CriadoEm = DateTime.UtcNow;

        SenhaHash = BCrypt.Net.BCrypt.HashPassword(senha);
    }

    public bool ValidarSenha(string senha)
    {
       
        return BCrypt.Net.BCrypt.Verify(senha, SenhaHash);
    }
}