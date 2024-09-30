using CSharpFunctionalExtensions;
using Desafio.WebApp.Domain.Pedidos.Events;
using Desafio.WebApp.Domain.Produtos.Events;
using Desafio.WebApp.Shared.Core.Entities;
using Desafio.WebApp.Shared.Core.Events;

namespace Desafio.WebApp.Domain.Produtos.Entities;

public class Produto : Entidade<int>
{
    public string NomeProduto { get; private set; }

    public decimal Preco { get; private set; }

    public int Estoque { get; private set; }
    
    public string EmailFornecedor { get; private set; }

    private Produto(string nomeProduto, decimal preco, int estoque)
    {
        NomeProduto = nomeProduto;
        Preco = preco;
        Estoque = estoque;
    }

    public static Result<Produto> CriarPedido(string nomeProduto, decimal preco, int estoque)
    {
        if (string.IsNullOrEmpty(nomeProduto))
            Result.Failure<Produto>("Nome do produto não pode estar em branco!");

        if (preco <= 0)
            Result.Failure<Produto>("O preco do produto deve ser maior que zero");

        if (estoque <= 0)
            Result.Failure<Produto>("O estoque do produto deve ser maior que zero");

        return Result.Success(new Produto(nomeProduto, preco, estoque));
    }

    public async Task<Result> AtualizarEstoque(int estoque)
    {
        if (Estoque < estoque || Estoque.Equals(0))
        {
            await DomainEvents.Raise(new ProdutoComEstoqueZeroEvent(Id));

            return Result.Failure("O produto está com estoque zerado");
        }
        
        Estoque = estoque;

        return Result.Success();
    }
}