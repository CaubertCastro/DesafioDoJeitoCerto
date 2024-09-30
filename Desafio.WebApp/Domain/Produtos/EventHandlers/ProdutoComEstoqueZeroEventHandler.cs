using Desafio.WebApp.Domain.Produtos.Events;
using Desafio.WebApp.Domain.Produtos.Repository.Contracts;
using Desafio.WebApp.Shared.Services.Contratos;
using MediatR;

namespace Desafio.WebApp.Domain.Produtos.EventHandlers
{
    public class ProdutoComEstoqueZeroEventHandler : INotificationHandler<ProdutoComEstoqueZeroEvent>
    {
        private readonly IEmailService _emailService;

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoComEstoqueZeroEventHandler(IEmailService emailService, IProdutoRepository produtoRepository)
        {
            _emailService = emailService;
            _produtoRepository = produtoRepository;
        }
        
        // Refatorar para colocar validações aqui tb.
        public async Task Handle(ProdutoComEstoqueZeroEvent notification, CancellationToken cancellationToken)
        {
            var produtoId = notification.produtoId;

            var produto = await _produtoRepository.ObterProduto(produtoId);
            
            const string subject = "produto com estoque zero";

            var body = $"O produto {produto.NomeProduto} está com o seu estoque zerado, favor entrar contato com departamento de compras para o estoque ser reposto";

            await _emailService.SendEmailAsync(produto.EmailFornecedor, subject, body);
        }
    }
}
