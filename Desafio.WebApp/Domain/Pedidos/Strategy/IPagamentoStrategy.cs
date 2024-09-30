using CSharpFunctionalExtensions;

namespace Desafio.WebApp.Domain.Pedidos.Strategy;

public interface IPagamentoStrategy
{
    decimal CalcularValor(decimal valorOriginal);

    Task<Result> ProcessarPagamento(decimal valorPagamento, int parcelas = 0);
}
