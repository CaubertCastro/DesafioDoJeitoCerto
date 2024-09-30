using CSharpFunctionalExtensions;
using Desafio.WebApp.Domain.Pedidos.Enums;
using Desafio.WebApp.Shared.Core.Entities;

namespace Desafio.WebApp.Domain.Pedidos.Entities
{
    public class PedidoPagamento : Entidade<int>
    {
        public TipoPagamento TipoPagamento { get; private set; }

        public int Parcelas { get; private set; }

        public bool Estornado { get; private set; }

        private PedidoPagamento(TipoPagamento tipoPagamento, int parcelas)
        {
            TipoPagamento = tipoPagamento;
            Parcelas = parcelas;
        }

        public static Result<PedidoPagamento> CriarPagamento(TipoPagamento tipoPagamento, int parcelas)
        {
            if (parcelas <= 0 || parcelas > 12)
                Result.Failure<PedidoPagamento>("O numero de parcelas deve ser maior que zero e menor que doze");

            return new PedidoPagamento(tipoPagamento, parcelas);
        }

        public static decimal AdicionarDescontoNoPix(decimal totalPedido)
        {
            // Esse valor poderia deixar configuração em alguma setting.
            var percentualDesconto = 0.05m;
            var desconto = totalPedido * percentualDesconto;

            return totalPedido - desconto;
        }

        public void MarcarPedidoComoEstornado()
        {
            Estornado = true;
        }
    }
}
