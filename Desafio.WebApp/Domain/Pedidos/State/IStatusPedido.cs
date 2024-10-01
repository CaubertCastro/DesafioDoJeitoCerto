using Desafio.WebApp.Domain.Pedidos.Entities;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.State;

public interface IStatusPedido
{
    Task Processar(Pedido pedido, IMediator mediator);
}