using Dispatcher.Abstractions;

namespace Dispatcher.Handlers;

/// <summary>
/// Handles a Message asynchronously without returning a value.
/// </summary>
/// <typeparam name="TMessage"></typeparam>
public interface IActionAsync<in TMessage> where TMessage : IMessage
{
    /// <summary>
    /// Handles a Message asynchronously
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task Handle(TMessage message, CancellationToken cancellation);
}