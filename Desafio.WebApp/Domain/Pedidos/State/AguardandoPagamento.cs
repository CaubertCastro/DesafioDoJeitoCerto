using Desafio.WebApp.Domain.Pedidos.Entities;
using Desafio.WebApp.Domain.Pedidos.Events;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.State;

public class AguardandoProcessamento : IStatusPedido
{
    public async Task Processar(Pedido pedido, IMediator mediator)
    {
        Console.WriteLine($"Pedido {pedido.Id} aguardando processamento.");
        
        await pedido.AtualizarStatusPedido(new ProcessandoPagamento());
        await mediator.Publish(new PedidoStatusChangedEvent(pedido.Id, pedido.Status));
    }
}

