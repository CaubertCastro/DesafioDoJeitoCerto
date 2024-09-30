using CSharpFunctionalExtensions;
using Desafio.WebApp.Domain.Pedidos.Entities;

namespace Desafio.WebApp.Domain.Pedidos.Strategy;

public class PagamentoPix : IPagamentoStrategy
{
    private readonly MockGatewayPagamento _gatewayPagamento;

    public PagamentoPix(MockGatewayPagamento gatewayPagamento)
    {
        _gatewayPagamento = gatewayPagamento;
    }

    public decimal CalcularValor(decimal valorOriginal)
    {
        return PedidoPagamento.AdicionarDescontoNoPix(valorOriginal);
    }

    public async Task<Result> ProcessarPagamento(decimal valorPagamento, int parcelas = 0)
    {
        try
        {
            // Serviço mocado de envio de processamento.
            await _gatewayPagamento.ProcessarPagamentoAsync(valorPagamento);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex.Message);
        }
    }
}
