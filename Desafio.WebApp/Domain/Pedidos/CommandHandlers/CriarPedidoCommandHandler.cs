using CSharpFunctionalExtensions;
using Desafio.WebApp.Domain.Pedidos.Commands;
using Desafio.WebApp.Domain.Pedidos.Entities;
using Desafio.WebApp.Domain.Pedidos.Repositories.Contratos;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.CommandHandlers;

public class CriarPedidoCommandHandler : IRequestHandler<CriarPedidoCommand, Result<int>>
{
    private readonly IMediator _mediator;
    private readonly IPedidoRepository _pedidoRepository;

    public CriarPedidoCommandHandler(IMediator mediator, IPedidoRepository pedidoRepository)
    {
        _mediator = mediator;
        _pedidoRepository = pedidoRepository;
    }

    // Passar essa lógica para PedidoDomainService
    public async Task<Result<int>> Handle(CriarPedidoCommand criarPedidoCommand, CancellationToken cancellationToken)
    {
        List<string> pedidoItemErros = [];

        var (usuario, pedidoItems) = criarPedidoCommand;

        var pedidoResult = Pedido.CriarPedido(usuario);

        if (pedidoResult.IsFailure)
            return Result.Failure<int>(pedidoResult.Error);

        var pedido = pedidoResult.Value;

        foreach (var (quantidade, preco) in pedidoItems)
        {
            var pedidoItemResult = PedidoItem.CriarPedidoItem(quantidade, preco);

            if (pedidoItemResult.IsFailure)
                pedidoItemErros.Add(pedidoItemResult.Error);

            pedido.AdicionarItem(pedidoItemResult.Value);
        };

        // Não é a melhor forma de resolver isto, mas vou deixar assim por enquanto.
        if (pedidoItemErros.Count > 0)
            return Result.Failure<int>(string.Join("; ", pedidoItemErros));

        pedido.CalcularTotalPedido();
        pedido.AtualizarQuantidadePedido();

        await _pedidoRepository.CriarPedidoAsync(pedido);

        return Result.Success(pedido.Id);
    }
}