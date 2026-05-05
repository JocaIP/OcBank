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
    public void Depositar(decimal valor)
    {
        if (valor <= 0)
            throw new Exception("Valor deve ser maior que zero");

        Saldo += valor;
    }
    public void Sacar(decimal valor)
    {
        if (valor <= 0)
            throw new Exception("Valor deve ser maior que zero");

        if (Saldo < valor)
        {
            throw new Exception("Saldo insuficiente");

    Saldo -= valor;
        }
    }
}