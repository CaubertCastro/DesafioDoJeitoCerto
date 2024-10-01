using Desafio.WebApp.Domain.Pedidos.Entities;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.State;

public class Cancelado : IStatusPedido
{
    public Task Processar(Pedido pedido, IMediator mediator)
    {
        Console.WriteLine($"Pedido {pedido.Id} está cancelado e não pode ser processado.");
        return Task.CompletedTask;
    }
}