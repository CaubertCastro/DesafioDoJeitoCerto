using Desafio.WebApp.Domain.Pedidos.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.WebApp.Domain.Pedidos.Controllers;

[ApiController]
[Route("[controller]")]
public class CancelarPedidoController : Controller
{
    private readonly IMediator _mediator;

    public CancelarPedidoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Cancelar([FromBody] CancelarPedidoCommand command)
    {
        var pedidoResult = await _mediator.Send(command);

        if (pedidoResult.IsFailure)
            return BadRequest(pedidoResult.Error);

        return Ok(pedidoResult.Value);
    }
}
