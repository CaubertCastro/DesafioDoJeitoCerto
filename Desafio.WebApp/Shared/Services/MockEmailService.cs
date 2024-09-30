using Desafio.WebApp.Shared.Services.Contratos;

namespace Desafio.WebApp.Shared.Services;

public class MockEmailService : IEmailService
{
    public async Task SendEmailAsync(string to, string subject, string body)
    {
        // Simula um atraso no envio do e-mail
        await Task.Delay(500);

        // Simula o envio do e-mail
        Console.WriteLine($"Email enviado para {to} com o assunto '{subject}' e corpo '{body}'");
    }
}