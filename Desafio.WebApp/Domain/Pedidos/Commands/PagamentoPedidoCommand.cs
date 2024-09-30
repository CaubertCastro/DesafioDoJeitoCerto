using CSharpFunctionalExtensions;
using Desafio.WebApp.Domain.Pedidos.Enums;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.Commands;

public record PagamentoPedidoCommand(int pedidoId, TipoPagamento tipoPagamento, int parcelas) : IRequest<Result<int>>;
