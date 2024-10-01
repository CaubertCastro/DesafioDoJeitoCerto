using Desafio.WebApp.Domain.Pedidos.Entities;
using Desafio.WebApp.Domain.Pedidos.Events;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.State;

public class AguardandoEstoque : IStatusPedido
{
    public async Task Processar(Pedido pedido, IMediator mediator)
    {
        Console.WriteLine($"Verificando estoque para o pedido {pedido.Id}.");
        
        await pedido.AtualizarStatusPedido(new Concluido());
        await mediator.Publish(new PedidoStatusChangedEvent(pedido.Id, pedido.Status));
    }
}