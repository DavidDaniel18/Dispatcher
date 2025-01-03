using InTransit.Abstractions;

namespace InTransit.Handlers;

/// <summary>
/// Handles a Message without returns.
/// </summary>
/// <typeparam name="TMessage"></typeparam>
public interface IAction<in TMessage> where TMessage : IMessage
{
    /// <summary>
    /// Handles a Message
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellation"></param>
    void Handle(TMessage message, CancellationToken cancellation);
}