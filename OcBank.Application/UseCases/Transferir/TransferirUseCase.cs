using OcBank.Application.Repositories;
using OcBank.Domain.Entities;
using OcBank.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcBank.Application.UseCases.Transferir
{
    public class TransferirUseCase
    {
        private readonly IContaRepositorio _contaRepositorio;
        private readonly ITransacaoRepositorio _transacaoRepositorio;

        public TransferirUseCase(
            IContaRepositorio contaRepositorio,
            ITransacaoRepositorio transacaoRepositorio)
        {
            _contaRepositorio = contaRepositorio;
            _transacaoRepositorio = transacaoRepositorio;
        }
        public async Task Executar(TransferirInput input)
        {
            if (input.ContaOrigemId == input.ContaDestinoId)

                throw new Exception("Não é possivel transferir para a mesma conta");


            if (input.Valor <= 0)
                throw new Exception("Valor deve ser maior que zero");

            var origem = await _contaRepositorio.ObterPorIdAsync(input.ContaOrigemId);
            var destino = await _contaRepositorio.ObterPorIdAsync(input.ContaDestinoId);

            if (origem == null || destino == null)
                throw new Exception("Conta não encontrada");

            origem.Sacar(input.Valor);
            destino.Depositar(input.Valor);

            origem.Sacar(input.Valor);
            destino.Depositar(input.Valor);

            await _contaRepositorio.AtualizarAsync(origem);
            await _contaRepositorio.AtualizarAsync(destino);

            await _transacaoRepositorio.CriarAsync(new Transacao
            {
                ContaId = origem.Id,
                Valor = input.Valor,
                Tipo = "Transferencia_Envio"
            });

            await _transacaoRepositorio.CriarAsync(new Transacao
            {
                ContaId = destino.Id,
                Valor = input.Valor,
                Tipo = "Transferencia_Recebida"
            });
        }
    }
}