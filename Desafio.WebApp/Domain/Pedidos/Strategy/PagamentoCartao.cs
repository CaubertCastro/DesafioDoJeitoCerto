using CSharpFunctionalExtensions;

namespace Desafio.WebApp.Domain.Pedidos.Strategy;

public class PagamentoCartao : IPagamentoStrategy
{
    private readonly MockGatewayPagamento _gatewayPagamento;

    public PagamentoCartao(MockGatewayPagamento gatewayPagamento)
    {
        _gatewayPagamento = gatewayPagamento;
    }

    public decimal CalcularValor(decimal valorOriginal)
    {
        return valorOriginal;
    }

    public async Task<Result> ProcessarPagamento(decimal valorPagamento, int parcelas)
    {
        try
        {
            await _gatewayPagamento.ProcessarPagamentoAsync(valorPagamento, parcelas);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex.Message);
        }
    }
}
