using InTransit.Abstractions;
using InTransit.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace InTransit.Registration;

/// <summary>
/// Registers the Dispatcher and Handlers in the ServiceCollection
/// </summary>
public static class ServiceRegistration
{
    /// <summary>
    /// Adds the Dispatcher and scans for Handlers in the calling assemblies
    /// </summary>
    /// <param name="collection"></param>
    /// <returns></returns>
    public static IServiceCollection AddDispatcherAndScanForHandlers(this IServiceCollection collection)
    {
        collection.AddScoped<IMessageDispatcher, MessageDispatcher>();

        var assemblyTypes = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type is { IsClass: true, IsAbstract: false });

        var handlerTypeRegister = new HandlerTypeRegister(collection, assemblyTypes);

        handlerTypeRegister.RegisterHandlers(typeof(IAction<>));
        handlerTypeRegister.RegisterHandlers(typeof(IFunction<,>));
        handlerTypeRegister.RegisterHandlers(typeof(IActionAsync<>));
        handlerTypeRegister.RegisterHandlers(typeof(IFunctionAsync<,>));

        return collection;
    }
}
