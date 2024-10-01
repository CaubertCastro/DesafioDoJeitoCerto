using Desafio.WebApp.Domain.Pedidos.Entities;
using Desafio.WebApp.Domain.Pedidos.Events;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.State;

public class SeparandoPedido : IStatusPedido
{
    public async Task Processar(Pedido pedido, IMediator mediator)
    {
        Console.WriteLine($"Separando itens do pedido {pedido.Id}.");
        
        await pedido.AtualizarStatusPedido(new AguardandoEstoque());
        await mediator.Publish(new PedidoStatusChangedEvent(pedido.Id, pedido.Status));
    }
}