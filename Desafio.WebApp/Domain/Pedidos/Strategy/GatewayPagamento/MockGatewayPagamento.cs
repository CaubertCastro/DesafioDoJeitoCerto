using Polly;
using Polly.Retry;

namespace Desafio.WebApp.Domain.Pedidos.Strategy;

public class MockGatewayPagamento
{
    private readonly AsyncRetryPolicy _retryPolicy;

    public MockGatewayPagamento()
    {
        _retryPolicy = Policy
            .Handle<Exception>()
            .RetryAsync(3);
    }

    public static MockGatewayPagamento CriarGatewayPagamento()
    {
        return new MockGatewayPagamento();
    }

    public async Task<bool> ProcessarPagamentoAsync(decimal valorPagamento, int parcelas = 0)
    {
        return await _retryPolicy.ExecuteAsync(async () =>
        {
            // Simula um atraso na comunicação com o gateway
            await Task.Delay(1000);

            // Simula uma resposta de sucesso ou falha
            bool isSuccess = new Random().Next(0, 2) == 0;

            if (!isSuccess)
                throw new Exception("Payment failed.");
            
            return isSuccess;
        });
    }
}
