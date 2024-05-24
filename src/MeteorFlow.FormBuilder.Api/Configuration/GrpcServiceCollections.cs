using MeteorFlow.Core.Grpc;
using MeteorFlow.Infrastructure.Grpc;

namespace MeteorFlow.FormBuilder.Api.Configuration;

public static class GrpcServiceCollections
{
    public static void AddGrpcServices(this IServiceCollection services, GrpcOptions? options)
    {
        services.AddSingleton<Definition.DefinitionClient>(_ =>
        {
            var channel = ChannelFactory.Create(options.Core);
            return new Definition.DefinitionClient(channel);
        });
    }
}