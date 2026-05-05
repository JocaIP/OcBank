using OcBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcBank.Infrastructure.Repositories
{
    public interface ITransacaoRepositorio
    {
        Task<List<Transacao>> ObterPorContaIdAsync(Guid contaId);
        Task CriarAsync(Transacao transacao);
    }
}
