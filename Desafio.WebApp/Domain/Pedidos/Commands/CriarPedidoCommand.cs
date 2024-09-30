using CSharpFunctionalExtensions;
using Desafio.WebApp.Domain.Pedidos.Request;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.Commands;

public record CriarPedidoCommand(string usuario, List<PedidoItemRequest> pedidoItems) : IRequest<Result<int>>;
