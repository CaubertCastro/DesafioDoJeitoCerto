namespace Desafio.WebApp.Domain.Pedidos.Request;

public record PedidoItemRequest(int produtoId, int quantidade, decimal preco);
