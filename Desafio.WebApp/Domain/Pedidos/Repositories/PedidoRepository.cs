using Desafio.WebApp.Domain.Pedidos.Entities;
using Desafio.WebApp.Domain.Pedidos.Repositories.Contratos;
using Desafio.WebApp.Shared.Context;

namespace Desafio.WebApp.Domain.Pedidos.Repositories;

public class PedidoRepository: IPedidoRepository
{
    private readonly DbContextDesafio _context;

    public PedidoRepository(DbContextDesafio context)
    {
        _context = context;
    }

    public async Task<Pedido?> ObterPedido(int pedidoId)
    {
        var pedido = await _context.Pedidos.FindAsync(pedidoId);

        return pedido;
    }

    public Task CancelarPedidoAsync(int pedidoId)
    {
        throw new NotImplementedException();
    }

    public async Task CriarPedidoAsync(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarPedidoAsync(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
    }
}
