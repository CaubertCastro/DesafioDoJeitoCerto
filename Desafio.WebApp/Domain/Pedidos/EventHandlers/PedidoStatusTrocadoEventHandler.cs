using Desafio.WebApp.Domain.Pedidos.Events;
using Desafio.WebApp.Domain.Pedidos.Repositories.Contratos;
using Desafio.WebApp.Shared.Services.Contratos;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.EventHandlers
{
    public class PedidoStatusTrocadoEventHandler : INotificationHandler<PedidoStatusTrocadoEvent>
    {
        private readonly IEmailService _emailService;

        private readonly IPedidoRepository _pedidoRepository;

        public PedidoStatusTrocadoEventHandler(IEmailService emailService, IPedidoRepository pedidoRepository)
        {
            _emailService = emailService;
            _pedidoRepository = pedidoRepository;
        }

        // Refatorar para colocar validações aqui tb.
        public async Task Handle(PedidoStatusTrocadoEvent notification, CancellationToken cancellationToken)
        {
            var (pedidoId, novoStatus) = notification;

            var pedido = await _pedidoRepository.ObterPedido(pedidoId);

            pedido?.AtualizarStatusPedido(novoStatus);

            
            // Configuração do email, está mocado com qualquer coisa,
            // mas o certo é ter um dominio de clientes onde é pego o email cadastro para envio do email.
            string email = "cliente@example.com";

            string subject = "Status do Pedido Atualizado";

            string body = $"O status do seu pedido foi atualizado para: {novoStatus}";

            await _emailService.SendEmailAsync(email, subject, body);
        }
    }
}
