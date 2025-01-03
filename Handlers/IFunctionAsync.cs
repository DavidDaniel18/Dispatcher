using Dispatcher.Abstractions;

namespace Dispatcher.Handlers;

/// <summary>
/// Handles a Message and returns a value asynchronously.
/// </summary>
/// <typeparam name="TMessage"></typeparam>
/// <typeparam name="TResult"></typeparam>
public interface IFunctionAsync<in TMessage, TResult> where TMessage : IMessage
{
    /// <summary>
    /// Handles a Message and returns a value asynchronously.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<TResult> Handle(TMessage message, CancellationToken cancellation);
}