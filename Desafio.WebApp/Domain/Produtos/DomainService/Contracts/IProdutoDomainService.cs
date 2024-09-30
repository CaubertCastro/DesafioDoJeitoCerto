using CSharpFunctionalExtensions;
using Desafio.WebApp.Domain.Produtos.Dtos;

namespace Desafio.WebApp.Domain.Produtos.DomainService.Contracts;

public interface IProdutoDomainService
{
    Task<Result> BaixarEstoqueProduto(IEnumerable<ProdutoEstoqueDto> produtos);
}