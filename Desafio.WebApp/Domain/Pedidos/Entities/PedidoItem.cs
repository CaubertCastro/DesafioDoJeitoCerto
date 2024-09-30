using CSharpFunctionalExtensions;
using Desafio.WebApp.Shared.Core.Entities;

namespace Desafio.WebApp.Domain.Pedidos.Entities;

public class PedidoItem : Entidade<int>
{
    public int PedidoId { get; private set; }

    public int ProdutoId { get; private set; }
    
    public int Quantidade { get; private set; }

    public decimal Preco { get; private set; }

    public static Result<PedidoItem> CriarPedidoItem(int produtoId, int quantidade, decimal preco)
    {
        if (produtoId <= 0)
            return Result.Failure<PedidoItem>("O id do produto não pode ser zero");
            
        if (quantidade <= 0)
            return Result.Failure<PedidoItem>("A quantidade de produtos deve ser maior que zero");

        if (preco <= 0)
            return Result.Failure<PedidoItem>("O preço do produto não pode ser menor ou igual a zero");

        return Result.Success(
            new PedidoItem
            {
                ProdutoId = produtoId,
                Preco = preco,
                Quantidade = quantidade,
            });
    }

    public decimal CalcularValorTotal()
    {
        decimal total = Preco * Quantidade;

        if (Quantidade >= 5 && total > 10)
            return total - 10;

        if (Quantidade >= 10 && total > 15)
            return total - 15;

        return 0;
    }

    public decimal CalcularDescontoSazonal(DateTime DataPedido)
    {
        decimal total = Preco * Quantidade;

        if (DataPedido.Month == 12)
            return total * 0.1m;

        if (DataPedido.DayOfWeek == DayOfWeek.Monday || DataPedido.DayOfWeek == DayOfWeek.Friday)
            return total * 0.05m;

        return 0;
    }

}
