using CSharpFunctionalExtensions;
using Desafio.WebApp.Domain.Pedidos.Enums;
using Desafio.WebApp.Domain.Pedidos.Events;
using Desafio.WebApp.Domain.Pedidos.State;
using Desafio.WebApp.Shared.Core.Entities;
using Desafio.WebApp.Shared.Core.Events;

namespace Desafio.WebApp.Domain.Pedidos.Entities;

public class Pedido : Entidade<int>
{
    public string Usuario { get; private set; }

    public DateTime DataPedido { get; private set; } = DateTime.Now;

    public decimal TotalPedido { get; private set; } = 0;

    public int QtdTotalPedido { get; private set; } = 0;

    public IStatusPedido Status { get; private set; }

    public PedidoPagamento Pagamento { get; private set; }

    private List<PedidoItem> _itensPedido = [];

    public IReadOnlyCollection<PedidoItem> ItensPedido => _itensPedido.AsReadOnly();

    private Pedido(string usuario)
    {
        Usuario = usuario;
        DataPedido = DateTime.Now;
    }

    public static Result<Pedido> CriarPedido(string usuario)
    {
        if (string.IsNullOrEmpty(usuario))
            return Result.Failure<Pedido>("O usuário não pode estar em branco");

        return Result.Success(new Pedido(usuario));
    }

    public void AdicionarItem(PedidoItem item)
    {
        _itensPedido.Add(item);
    }

    public void AdicionarPagamento(PedidoPagamento pagamento)
    {
        Pagamento = pagamento;
    }

    public void CalcularTotalPedido()
    {
        decimal subtotal = _itensPedido.Sum(item => item.CalcularValorTotal());
        decimal descontoSazonal = _itensPedido.Sum(item => item.CalcularDescontoSazonal(DataPedido));

        TotalPedido = subtotal - descontoSazonal;
    }

    public void AtualizarTotalPedido(decimal totalPedido)
    {
        TotalPedido = totalPedido;
    }

    public void AtualizarQuantidadePedido()
    {
        QtdTotalPedido = _itensPedido.Count();
    }

    public async Task AtualizarStatusPedido(IStatusPedido novoStatus)
    {
        Status = novoStatus;
        
        await DomainEvents.Raise(new PedidoStatusChangedEvent(Id, Status));
    }
}