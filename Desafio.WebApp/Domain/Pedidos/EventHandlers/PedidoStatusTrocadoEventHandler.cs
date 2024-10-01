using Desafio.WebApp.Domain.Pedidos.Events;
using Desafio.WebApp.Domain.Pedidos.Repositories.Contracts;
using Desafio.WebApp.Shared.Services.Contratos;
using MediatR;

namespace Desafio.WebApp.Domain.Pedidos.EventHandlers
{
    public class PedidoStatusTrocadoEventHandler : INotificationHandler<PedidoStatusChangedEvent>
    {
        private readonly IEmailService _emailService;
        
        public PedidoStatusTrocadoEventHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }
        
        public async Task Handle(PedidoStatusChangedEvent notification, CancellationToken cancellationToken)
        {
            // Configuração do email, está mocado com qualquer coisa,
            // Criar dominio de clientes para cadastrar um cliente e obter o email cadastro.
            const string email = "cliente@example.com";

            const string subject = "Status do Pedido Atualizado";

            var body = $"O status do seu pedido foi atualizado para: {notification.NovoStatus.GetType().Name}";

            await _emailService.SendEmailAsync(email, subject, body);
        }
    }
}
