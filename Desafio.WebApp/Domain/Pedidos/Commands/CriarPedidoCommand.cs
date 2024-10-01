using CSharpFunctionalExtensions;
using Desafio.WebApp.Domain.Pedidos.Request;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.Commands;

public record CriarPedidoCommand(string Usuario, List<PedidoItemRequest> PedidoItems) : IRequest<Result<int>>;
