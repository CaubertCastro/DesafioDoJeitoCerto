using Desafio.WebApp.Domain.Pedidos.State;
using Desafio.WebApp.Shared.Core.Events;

namespace Desafio.WebApp.Domain.Pedidos.Events;

public record PedidoStatusChangedEvent(int PedidoId, IStatusPedido NovoStatus): IDomainEvent;
