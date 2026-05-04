using Microsoft.EntityFrameworkCore;
using OcBank.Domain.Entities;
using OcBank.Infrastructure.Data;

namespace OcBank.Infrastructure.Repositories;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly AppDbContext _context;

    public UsuarioRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task CriarAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Usuario>> ObterTodosAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }
    public async Task<Usuario?> ObterPorEmailAsync(string email)
    {
        return await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Email == email);
    }
}