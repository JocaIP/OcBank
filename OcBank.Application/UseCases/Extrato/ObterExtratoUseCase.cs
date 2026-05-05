using OcBank.Domain.Entities;
using OcBank.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcBank.Application.UseCases.Extrato
{
    public class ObterExtratoUseCase
    {
        private readonly ITransacaoRepositorio _repositorio;

        public ObterExtratoUseCase(ITransacaoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<List<Transacao>> Executar(Guid contaId)
        {
            return await _repositorio.ObterPorContaIdAsync(contaId);
        }
    }
}
