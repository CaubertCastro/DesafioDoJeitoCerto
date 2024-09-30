namespace Desafio.WebApp.Shared.Services.Contratos;

public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body);
}
