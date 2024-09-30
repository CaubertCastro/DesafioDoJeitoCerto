using CSharpFunctionalExtensions;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.Commands;

public record BaixarEstoquePedidoCommand(int pedidoId) : IRequest<Result<int>>;
