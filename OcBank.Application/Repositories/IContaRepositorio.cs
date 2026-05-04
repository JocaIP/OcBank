using OcBank.Domain.Entities;

namespace OcBank.Application.Repositories
{
    public interface IContaRepositorio
    {
            Task CriarAsync(Conta conta);
    }
}
