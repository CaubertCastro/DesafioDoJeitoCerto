using Desafio.WebApp.Domain.Pedidos.Entities;

namespace Desafio.WebApp.Domain.Pedidos.Repositories.Contracts;

public interface IPedidoRepository
{
    Task<Pedido?> ObterPedido(int pedidoId);

    Task CriarPedidoAsync(Pedido pedido);

    Task AtualizarPedidoAsync(Pedido pedido);

    Task CancelarPedidoAsync(int idPedido);
}
