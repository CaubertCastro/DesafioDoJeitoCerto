using MediatR;

namespace Desafio.WebApp.Shared.Core.Events;

public static class DomainEvents
{
    private static IMediator _mediator;

    public static void Configure(IMediator mediator)
    {
        _mediator = mediator;
    }

    public static async Task Raise<T>(T args) where T : IDomainEvent
    {
        if (_mediator == null)
            throw new InvalidOperationException("Houve um problema ao executar o método Raise.");

        await _mediator.Publish(args);
    }
}
