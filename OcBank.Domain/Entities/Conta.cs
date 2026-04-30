namespace OcBank.Domain.Entities;

public class Conta
{
    public Guid Id { get; private set; }
    public Guid UsuarioId { get; private set; }
    public decimal Saldo { get; private set; }
    public DateTime CriadoEm { get; private set; }

    public Conta(Guid usuarioId)
    {
        Id = Guid.NewGuid();
        UsuarioId = usuarioId;
        Saldo = 0;
        CriadoEm = DateTime.UtcNow;
    }
}