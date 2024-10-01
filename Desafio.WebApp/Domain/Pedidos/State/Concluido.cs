using Desafio.WebApp.Domain.Pedidos.Entities;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.State;

public class Concluido : IStatusPedido
{
    public Task Processar(Pedido pedido, IMediator mediator)
    {
        Console.WriteLine($"Pedido {pedido.Id} já está concluído.");
        return Task.CompletedTask;
    }
}