using CSharpFunctionalExtensions;
using Desafio.WebApp.Domain.Pedidos.Commands;
using Desafio.WebApp.Domain.Pedidos.Repositories.Contratos;

using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.CommandHandlers;

public class BaixarEstoquePedidoCommandHandler : IRequestHandler<BaixarEstoquePedidoCommand, Result<int>>
{
    private readonly IPedidoRepository _pedidoRepository;

    public BaixarEstoquePedidoCommandHandler(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    // Passar essa lógica para PagamentoPedidoDomainService
    public async Task<Result<int>> Handle(BaixarEstoquePedidoCommand baixarEstoqueCommand, CancellationToken cancellationToken)
    {
        var pedidoId = baixarEstoqueCommand.pedidoId;

        // Busca o pedido 
        // Busca os items do pedido
        // Foreach para fazer a baixa dos items do pedido
        // Metodo no PedidoItem para fazer a baixa do estoque
        // Executa um domainEvent.raise para chamar o Service que diminue o estoque no dominio de produtos

        // Refatorar o método de pedidos para receber o IdProduto.


        return Result.Success(pedido.Id);
    }
}