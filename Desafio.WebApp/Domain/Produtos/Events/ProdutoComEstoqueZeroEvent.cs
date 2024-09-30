using Desafio.WebApp.Shared.Core.Events;

namespace Desafio.WebApp.Domain.Produtos.Events;

public record ProdutoComEstoqueZeroEvent(int produtoId): IDomainEvent;
