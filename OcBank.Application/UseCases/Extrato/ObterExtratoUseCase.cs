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
        public async Task<List<ExtratoOutput>> Executar(Guid contaId)
        {
            var transacoes = await _repositorio.ObterPorContaIdAsync(contaId);

            return transacoes
                .OrderByDescending(t => t.Data)
                .Select(t => new ExtratoOutput
                {
                    Valor = t.Valor,
                    Tipo = t.Tipo,
                    Data = t.Data,
                    Descricao = GerarDescricao(t.Tipo, t.Valor)
                })
                .ToList();
        }
        private string GerarDescricao(string tipo, decimal valor)
        {

            return tipo switch
            {
                "Deposito" => $"Depósito de {valor}",
                "Saque" => $"Saque de {valor}",
                "Transferencia_Envio" => $"Transferência enviada de {valor}",
                "Transferencia_Recebida" => $"Transferência recebida de {valor}",
                _ => "Movimentação"
            };
        }
    }
}

