using Desafio.WebApp.Domain.Pedidos.Entities;
using Desafio.WebApp.Domain.Produtos.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio.WebApp.Shared.Context;

public class DbContextDesafio : DbContext
{
    public DbSet<Pedido> Pedidos { get; set; }
    
    public DbSet<PedidoItem> PedidosItem { get; set; }
    
    public DbSet<Produto> Produtos { get; set; }

    public DbContextDesafio(DbContextOptions<DbContextDesafio> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Melhorar modelo do banco de dados com migrations posteriores ... 
        modelBuilder.Entity<Pedido>()
            .Property(p => p.Usuario)
            .IsRequired()
            .HasMaxLength(200);

        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Pagamento)
            .WithOne()
            .HasForeignKey<PedidoPagamento>(p => p.Id);

        modelBuilder.Entity<Pedido>()
            .ToTable("Pedidos")
            .HasKey(p => p.Id);

        modelBuilder.Entity<PedidoPagamento>()
            .ToTable("Pedidos")
            .HasKey(p => p.Id);

    }
}
