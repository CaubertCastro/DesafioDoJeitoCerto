using Desafio.WebApp.Domain.Pedidos.Entities;
using Desafio.WebApp.Domain.Pedidos.Events;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.State;

public class PagamentoConcluido : IStatusPedido
{
    public async Task Processar(Pedido pedido, IMediator mediator)
    {
        Console.WriteLine($"Pagamento do pedido {pedido.Id} concluído.");
        
        await pedido.AtualizarStatusPedido(new SeparandoPedido());
        await mediator.Publish(new PedidoStatusChangedEvent(pedido.Id, pedido.Status));
    }
}