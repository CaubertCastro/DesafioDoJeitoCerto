using Desafio.WebApp.Domain.Produtos.Entities;
using Desafio.WebApp.Domain.Produtos.Repository.Contracts;
using Desafio.WebApp.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.WebApp.Domain.Produtos.Repository;

public class ProdutoRepository: IProdutoRepository
{
    private readonly DbContextDesafio _context;

    public ProdutoRepository(DbContextDesafio context)
    {
        _context = context;
    }

    public IEnumerable<Produto> ListarProdutosPorListaDeIds(IEnumerable<int> produtosIds)
    {
        return _context.Produtos.AsNoTracking().Where(prd => produtosIds.Contains(prd.Id));
    }

    public async Task<Produto?> ObterProduto(int produtoId)
    {
        return await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(w => w.Id == produtoId);
    }

    public async Task AtualizarProdutoAsync(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }
}