using Dispatcher.Abstractions;
using Dispatcher.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Dispatcher.Registration;

static class ServiceRegistration
{
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
