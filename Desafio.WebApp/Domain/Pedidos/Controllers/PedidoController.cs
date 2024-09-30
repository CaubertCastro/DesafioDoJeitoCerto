using Desafio.WebApp.Domain.Pedidos.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.WebApp.Domain.Pedidos.Controllers;

[ApiController]
[Route("[controller]")]
public class PedidoController : Controller
{
    private readonly IMediator _mediator;

    public PedidoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CriarPedido([FromBody] CriarPedidoCommand command)
    {
        var pedidoResult = await _mediator.Send(command);

        if (pedidoResult.IsFailure)
            return BadRequest(pedidoResult.Error);

        return Ok(pedidoResult.Value);
    }
}
