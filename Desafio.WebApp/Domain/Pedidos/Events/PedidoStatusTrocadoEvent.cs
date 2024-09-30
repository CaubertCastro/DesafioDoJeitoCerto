using Desafio.WebApp.Domain.Pedidos.Enums;
using Desafio.WebApp.Shared.Core.Events;

namespace Desafio.WebApp.Domain.Pedidos.Events;

public record PedidoStatusTrocadoEvent(int pedidoId, StatusPedido statusPedido): IDomainEvent;
