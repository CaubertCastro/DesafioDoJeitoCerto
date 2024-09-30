using CSharpFunctionalExtensions;
using Desafio.WebApp.Domain.Pedidos.Commands;
using Desafio.WebApp.Domain.Pedidos.Entities;
using Desafio.WebApp.Domain.Pedidos.Enums;
using Desafio.WebApp.Domain.Pedidos.Repositories.Contracts;
using Desafio.WebApp.Domain.Pedidos.Strategy;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.CommandHandlers;

public class PagamentoPedidoCommandHandler : IRequestHandler<PagamentoPedidoCommand, Result<int>>
{
    private readonly IPedidoRepository _pedidoRepository;

    public PagamentoPedidoCommandHandler(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    // Passar essa lógica para PagamentoPedidoDomainService
    public async Task<Result<int>> Handle(PagamentoPedidoCommand pagarPedidoCommand, CancellationToken cancellationToken)
    {
        var (pedidoId, tipoPagamento, parcelas) = pagarPedidoCommand;

        // Obtem o pedido pelo id
        var pedido = await _pedidoRepository.ObterPedido(pedidoId);

        if (pedido == null)
            Result.Failure<int>("Não foi encontrado nenhum pedido com o id informado!");

        // Troca o status do pedido para o Processando Pagamento, eu sei que não é a melhor forma, mas é a melhor solução me veio no momento.
        await pedido.AtualizarStatusPedido(StatusPedido.ProcessandoPagamento);

        // Cria o pagamento
        var pagamentoResult = PedidoPagamento.CriarPagamento(tipoPagamento, parcelas);

        if (pagamentoResult.IsFailure)
            return Result.Failure<int>(pagamentoResult.Error);

        // valida se o pedido está no estatus certo para o pagamento
        if (pedido.StatusPedido != StatusPedido.ProcessandoPagamento)
            return Result.Failure<int>("O pedido precisa estar no status de processando pagamento para prosseguir a operação!");

        // Stategy de pagamento.        
        var estrategiaDePagamento = PagamentoFactory.ObterEstrategiaDePagamento(tipoPagamento);
        var valorComDesconto = estrategiaDePagamento.CalcularValor(pedido.TotalPedido);

        var processamentoPagamentoResult = await estrategiaDePagamento.ProcessarPagamento(valorComDesconto, parcelas);

        if (processamentoPagamentoResult.IsFailure)
        {
            //Atualiza o status do pedido para cancelado.
            await pedido.AtualizarStatusPedido(StatusPedido.Cancelado);

            await _pedidoRepository.AtualizarPedidoAsync(pedido);

            return Result.Failure<int>(processamentoPagamentoResult.Error);
        }

        pedido.AdicionarPagamento(pagamentoResult.Value);

        await pedido.AtualizarStatusPedido(StatusPedido.PagamentoConcluido);

        pedido.AtualizarTotalPedido(valorComDesconto);

        await _pedidoRepository.AtualizarPedidoAsync(pedido);

        return Result.Success(pedido.Id);
    }
}