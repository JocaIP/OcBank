using OcBank.Application.Repositories;
using OcBank.Domain.Entities;
using OcBank.Infrastructure.Repositories;

public class DepositarUseCase
{
    private readonly IContaRepositorio _repositorio;
    private readonly ITransacaoRepositorio _transacaoRepositorio;

    public DepositarUseCase(IContaRepositorio repositorio, ITransacaoRepositorio transacaoRepositorio)
    {
        _repositorio = repositorio;
        _transacaoRepositorio = transacaoRepositorio;
    }

    public async Task Executar(DepositarInput input)
    {
        if (input.Valor <= 0)
            throw new Exception("Valor deve ser maior que zero");

        var conta = await _repositorio.ObterPorIdAsync(input.ContaId);

        if (conta == null)
            throw new Exception("Conta não encontrada");

        conta.Depositar(input.Valor);

        await _repositorio.AtualizarAsync(conta);

        var transacao = new Transacao
        {
            ContaId = conta.Id,
            Valor = input.Valor,
            Tipo = "Deposito"
        };

        await _transacaoRepositorio.CriarAsync(transacao);
    }
}