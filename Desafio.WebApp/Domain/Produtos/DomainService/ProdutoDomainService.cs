using CSharpFunctionalExtensions;
using Desafio.WebApp.Domain.Produtos.DomainService.Contracts;
using Desafio.WebApp.Domain.Produtos.Dtos;
using Desafio.WebApp.Domain.Produtos.Repository.Contracts;

namespace Desafio.WebApp.Domain.Produtos.DomainService;

public class ProdutoDomainService: IProdutoDomainService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoDomainService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    
    public async Task<Result> BaixarEstoqueProduto(IEnumerable<ProdutoEstoqueDto> produtos)
    {
        List<string> erros = [];
        
         // foreach no dados para obter o produto e fazer a atualização do estoque    
         foreach (var (produtoId, quantidade) in produtos)
         {
             // obtem o produto, não é a forma mais otimizada do mundo, mas pode ser melhorado depois.
             var produto = await _produtoRepository.ObterProduto(produtoId);
             
             var produtoResult = await produto.AtualizarEstoque(quantidade);

             if (!produtoResult.IsFailure)
                 await _produtoRepository.AtualizarProdutoAsync(produto);
             
             erros.Add(produtoResult.Error);
         }

         return erros.Count > 0 ? Result.Failure(string.Join("; ", erros)) : Result.Success();
    }
}