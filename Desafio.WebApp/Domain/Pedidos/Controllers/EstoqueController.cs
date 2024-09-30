using Desafio.WebApp.Domain.Pedidos.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.WebApp.Domain.Pedidos.Controllers;

[ApiController]
[Route("[controller]")]
public class EstoqueController : Controller
{
    private readonly IMediator _mediator;

    public EstoqueController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> FazerPagamento([FromBody] BaixarEstoquePedidoCommand command)
    {
        var baixarEstoqueResult = await _mediator.Send(command);

        if (baixarEstoqueResult.IsFailure)
            return BadRequest(baixarEstoqueResult.Error);

        return Ok(baixarEstoqueResult.Value);
    }
}
