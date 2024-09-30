using Desafio.WebApp.Domain.Produtos.Entities;

namespace Desafio.WebApp.Domain.Produtos.Repository.Contracts;

public interface IProdutoRepository
{
    IEnumerable<Produto> ListarProdutosPorListaDeIds(IEnumerable<int> produtosIds);
    
    Task<Produto?> ObterProduto(int produtoId);
    
    Task AtualizarProdutoAsync(Produto produto);
}