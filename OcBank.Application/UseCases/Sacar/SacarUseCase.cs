using OcBank.Application.Repositories;
using OcBank.Domain.Entities;
using OcBank.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcBank.Application.UseCases.Sacar
{
    public class SacarUseCase
    {
        private readonly IContaRepositorio _repositorio;
        private readonly ITransacaoRepositorio _transacaoRepositorio;

        public SacarUseCase(IContaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task Executar(SacarInput input)
        {
            var conta = await _repositorio.ObterPorIdAsync(input.ContaId);

            if (conta == null)
                throw new Exception("Conta não encontrada");

            conta.Sacar(input.Valor);

            await _repositorio.AtualizarAsync(conta);

            await _transacaoRepositorio.CriarAsync(new Transacao
            {
                ContaId = conta.Id,
                Valor = input.Valor,
                Tipo = "Saque"
            });
        }
    }
}
