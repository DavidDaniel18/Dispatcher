using Microsoft.Extensions.DependencyInjection;

namespace Dispatcher.Registration;

internal sealed class HandlerTypeRegister
{
    private readonly IServiceCollection _collection;
    private readonly IEnumerable<Type> _types;

    internal HandlerTypeRegister(IServiceCollection collection, IEnumerable<Type> types)
    {
        _collection = collection;
        _types = types;
    }

    internal void RegisterHandlers(Type handlerInterfaceType)
    {
        var types = _types.SelectMany(type => type.GetInterfaces()
                .Where(@interface => @interface.IsGenericType && @interface.GetGenericTypeDefinition() == handlerInterfaceType)
                .Select(@interface => new { ImplementationType = type, InterfaceType = @interface }))
            .ToList();

        types.ForEach(type => _collection.AddScoped(type.InterfaceType, type.ImplementationType));
    }
}