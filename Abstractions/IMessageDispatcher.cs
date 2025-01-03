namespace InTransit.Abstractions;

/// <summary>
/// Interface for a Message Dispatcher.
/// </summary>
public interface IMessageDispatcher
{
    /// <summary>
    /// Dispatches a Message.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellation"></param>
    /// <typeparam name="TMessage"></typeparam>
    void Dispatch<TMessage>(TMessage message, CancellationToken cancellation) where TMessage : IMessage;

    /// <summary>
    /// Dispatches a Message asynchronously.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellation"></param>
    /// <typeparam name="TMessage"></typeparam>
    /// <returns></returns>
    Task DispatchAsync<TMessage>(TMessage message, CancellationToken cancellation) where TMessage : IMessage;

    /// <summary>
    /// Dispatches a Message and returns a value.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellation"></param>
    /// <typeparam name="TMessage"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    TResult Dispatch<TMessage, TResult>(TMessage message, CancellationToken cancellation) where TMessage : IMessage;

    /// <summary>
    /// Dispatches a Message and returns a value asynchronously.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellation"></param>
    /// <typeparam name="TMessage"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    Task<TResult> DispatchAsync<TMessage, TResult>(TMessage message, CancellationToken cancellation) where TMessage : IMessage;
}