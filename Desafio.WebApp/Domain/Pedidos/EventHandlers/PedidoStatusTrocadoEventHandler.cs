using Desafio.WebApp.Domain.Pedidos.Events;
using Desafio.WebApp.Domain.Pedidos.Repositories.Contracts;
using Desafio.WebApp.Shared.Services.Contratos;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.EventHandlers
{
    public class PedidoStatusTrocadoEventHandler : INotificationHandler<PedidoStatusTrocadoEvent>
    {
        private readonly IEmailService _emailService;
        
        public PedidoStatusTrocadoEventHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        // Refatorar para colocar validações aqui tb.
        public async Task Handle(PedidoStatusTrocadoEvent notification, CancellationToken cancellationToken)
        {
            var novoStatus = notification.statusPedido;

            // Configuração do email, está mocado com qualquer coisa,
            // mas o certo é ter um dominio de clientes onde é pego o email cadastro para envio do email.
            const string email = "cliente@example.com";

            const string subject = "Status do Pedido Atualizado";

            var body = $"O status do seu pedido foi atualizado para: {novoStatus}";

            await _emailService.SendEmailAsync(email, subject, body);
        }
    }
}
