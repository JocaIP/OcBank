using OcBank.Domain.Entities;

namespace OcBank.Application.Repositories
{
    public interface IContaRepositorio
    {
        Task CriarAsync(Conta conta);
        Task<Conta?> ObterPorIdAsync(Guid contaId);
        Task AtualizarAsync(Conta conta);
    }
}
