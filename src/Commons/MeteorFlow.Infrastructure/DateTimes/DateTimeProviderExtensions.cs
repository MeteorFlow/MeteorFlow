using MeteorFlow.Fx.DateTimes;
using Microsoft.Extensions.DependencyInjection;

namespace MeteorFlow.Infrastructure.DateTimes;

public static class DateTimeProviderExtensions
{
    public static IServiceCollection AddDateTimeProvider(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}