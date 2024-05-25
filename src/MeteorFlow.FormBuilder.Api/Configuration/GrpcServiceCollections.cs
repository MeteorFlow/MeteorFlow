using MeteorFlow.Core.Grpc;
using MeteorFlow.Infrastructure.Grpc;

namespace MeteorFlow.FormBuilder.Api.Configuration;

public static class GrpcServiceCollections
{
    public static void AddGrpcServices(this IServiceCollection services, GrpcOptions options)
    {
        var channel = ChannelFactory.Create(options.Core);
        services.AddSingleton(new Definition.DefinitionClient(channel));
    }
}