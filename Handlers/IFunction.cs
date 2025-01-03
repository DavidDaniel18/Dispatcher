using InTransit.Abstractions;

namespace InTransit.Handlers;

/// <summary>
/// Handles a Message and returns a value.
/// </summary>
/// <typeparam name="TMessage"></typeparam>
/// <typeparam name="TResult"></typeparam>
public interface IFunction<in TMessage, out TResult> where TMessage : IMessage
{
    /// <summary>
    /// Handles a Message and returns a value.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    TResult Handle(TMessage message, CancellationToken cancellation);
}