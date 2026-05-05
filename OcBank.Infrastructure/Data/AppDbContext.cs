using Microsoft.EntityFrameworkCore;
using OcBank.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace OcBank.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Conta> Contas { get; set; }
    public DbSet<Transacao> Transacoes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Nome).IsRequired();
            entity.Property(u => u.Email).IsRequired();
        });

        modelBuilder.Entity<Conta>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Saldo).IsRequired();
        });
    }
}