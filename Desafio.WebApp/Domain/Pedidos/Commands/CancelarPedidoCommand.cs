using CSharpFunctionalExtensions;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.Commands;

public record CancelarPedidoCommand(int PedidoId): IRequest<Result<string>>;
