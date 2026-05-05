using Microsoft.EntityFrameworkCore;
using OcBank.Application.Repositories;
using OcBank.Domain.Entities;
using OcBank.Infrastructure.Data;

namespace OcBank.Infrastructure.Repositories
{
    public class ContaRepositorio : IContaRepositorio
    {
        private readonly AppDbContext _context;

        public ContaRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public async Task CriarAsync(Conta conta)
        {
            await _context.Contas.AddAsync(conta);
            await _context.SaveChangesAsync();
        }
        public async Task<Conta?> ObterPorIdAsync(Guid contaId)
        {
            return await _context.Contas
                .FirstOrDefaultAsync(c => c.Id == contaId);
        }

        public async Task AtualizarAsync(Conta conta)
        {
            _context.Contas.Update(conta);
            await _context.SaveChangesAsync();
        }
    }
}
