using Desafio.WebApp.Domain.Pedidos.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.WebApp.Domain.Pedidos.Controllers;

[ApiController]
[Route("[controller]")]
public class PagamentoController : Controller
{
    private readonly IMediator _mediator;

    public PagamentoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> FazerPagamento([FromBody] PagamentoPedidoCommand command)
    {
        var pagamentoResult = await _mediator.Send(command);

        if (pagamentoResult.IsFailure)
            return BadRequest(pagamentoResult.Error);

        return Ok(pagamentoResult.Value);
    }
}
