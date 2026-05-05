using OcBank.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcBank.Application.UseCases.Saldo
{
    public class ObterSaldoUseCase
    {
        private readonly IContaRepositorio _repositorio;

        public ObterSaldoUseCase(IContaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<decimal> Executar(Guid contaId)
        {
            var conta = await _repositorio.ObterPorIdAsync(contaId);

            if (conta == null)
                throw new Exception("Conta não encontrada");

            return conta.Saldo;
        }
    }
}
