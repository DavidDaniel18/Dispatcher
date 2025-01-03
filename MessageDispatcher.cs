using Dispatcher.Abstractions;
using Dispatcher.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Dispatcher;

internal sealed class MessageDispatcher(IServiceProvider serviceProvider) : IMessageDispatcher
{
    public void Dispatch<TMessage>(TMessage message, CancellationToken cancellation) where TMessage : IMessage
    {
        var scope = serviceProvider.CreateScope();

        var handler = scope.ServiceProvider.GetRequiredService<IAction<TMessage>>();

        handler.Handle(message, cancellation);
    }

    public async Task DispatchAsync<TMessage>(TMessage message, CancellationToken cancellation) where TMessage : IMessage
    {
        var scope = serviceProvider.CreateScope();

        var handler = scope.ServiceProvider.GetRequiredService<IActionAsync<TMessage>>();

        await handler.Handle(message, cancellation);
    }

    public TResult Dispatch<TMessage, TResult>(TMessage message, CancellationToken cancellation) where TMessage : IMessage
    {
        var handler = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IFunction<TMessage, TResult>>();

        return handler.Handle(message, cancellation);
    }

    public async Task<TResult> DispatchAsync<TMessage, TResult>(TMessage message, CancellationToken cancellation) where TMessage : IMessage
    {
        var handler = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IFunctionAsync<TMessage, TResult>>();

        return await handler.Handle(message, cancellation);
    }
}