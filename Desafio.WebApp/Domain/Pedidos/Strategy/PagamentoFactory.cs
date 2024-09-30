using Desafio.WebApp.Domain.Pedidos.Enums;

namespace Desafio.WebApp.Domain.Pedidos.Strategy;

public class PagamentoFactory
{
    public static IPagamentoStrategy ObterEstrategiaDePagamento(TipoPagamento tipoPagamento)
    {
        var mockGateway = MockGatewayPagamento.CriarGatewayPagamento();

        return tipoPagamento switch
        {
            TipoPagamento.Pix => new PagamentoPix(mockGateway),
            TipoPagamento.CartaoDeCredito => new PagamentoCartao(mockGateway),
            _ => throw new ArgumentException("Tipo de pagamento inválido")
        };
    }
}
