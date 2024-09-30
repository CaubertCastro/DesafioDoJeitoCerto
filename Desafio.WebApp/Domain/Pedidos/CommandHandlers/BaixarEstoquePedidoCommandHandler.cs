using CSharpFunctionalExtensions;
using Desafio.WebApp.Domain.Pedidos.Commands;
using Desafio.WebApp.Domain.Pedidos.Repositories.Contracts;
using Desafio.WebApp.Domain.Produtos.DomainService.Contracts;
using Desafio.WebApp.Domain.Produtos.Dtos;
using Desafio.WebApp.Domain.Produtos.Repository.Contracts;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.CommandHandlers;

public class BaixarEstoquePedidoCommandHandler : IRequestHandler<BaixarEstoquePedidoCommand, Result<int>>
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IProdutoDomainService _produtoDomainService;

    public BaixarEstoquePedidoCommandHandler(IPedidoRepository pedidoRepository, IProdutoDomainService produtoDomainService)
    {
        _pedidoRepository = pedidoRepository;
        _produtoDomainService = produtoDomainService;
    }

    // Passar essa lógica para ProdutosDomainService
    public async Task<Result<int>> Handle(BaixarEstoquePedidoCommand baixarEstoqueCommand,
        CancellationToken cancellationToken)
    {
        var pedidoId = baixarEstoqueCommand.pedidoId;
        
        var pedido = await _pedidoRepository.ObterPedido(pedidoId);

        // Validar se o pedido não é null
        
        var produtos = pedido.ItensPedido.Select(s
            => new ProdutoEstoqueDto(s.ProdutoId, s.Quantidade));
        
        var estoqueResult = await _produtoDomainService.BaixarEstoqueProduto(produtos);
        
        return estoqueResult.IsFailure ? Result.Failure<int>(estoqueResult.Error) : Result.Success(pedido.Id);
    }
}