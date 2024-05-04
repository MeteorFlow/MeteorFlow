using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Queries;

namespace MeteorFlow.Fx;

internal static class Utils
{
    public static bool IsHandlerInterface(Type type)
    {
        if (!type.IsGenericType)
        {
            return false;
        }

        var typeDefinition = type.GetGenericTypeDefinition();

        return typeDefinition == typeof(ICommandHandler<,>)
               || typeDefinition == typeof(IQueryHandler<,>);
    }
}