using Microsoft.EntityFrameworkCore;
using OcBank.Domain.Entities;
using OcBank.Infrastructure.Data;

namespace OcBank.Infrastructure.Repositories;

public class TransacaoRepositorio : ITransacaoRepositorio
{
    private readonly AppDbContext _context;

    public TransacaoRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Transacao>> ObterPorContaIdAsync(Guid contaId)
    {
        return await _context.Transacoes
            .Where(t => t.ContaId == contaId)
            .ToListAsync();
    }

    public async Task CriarAsync(Transacao transacao)
    {
        await _context.Transacoes.AddAsync(transacao);
        await _context.SaveChangesAsync();
    }
}