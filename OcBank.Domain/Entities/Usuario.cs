using static System.Net.Mime.MediaTypeNames;

namespace OcBank.Domain.Entities;

public class Usuario
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public DateTime CriadoEm { get; private set; }

    public ICollection<Conta> Contas { get; private set; } = new List<Conta>();

    public Usuario(string nome, string email)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        CriadoEm = DateTime.UtcNow;
    }
}