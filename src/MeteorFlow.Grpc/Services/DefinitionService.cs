using AutoMapper;
using Grpc.Core;
using MeteorFlow.Core.Definitions.Commands;
using MeteorFlow.Core.Definitions.Queries;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Queries;
using MeteorFlow.Core.Grpc;
using Microsoft.AspNetCore.Authorization;
using static MeteorFlow.Core.Grpc.Definition;

namespace MeteorFlow.Grpc.Services;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="commandDispatcher"></param>
/// <param name="queryDispatcher"></param>
/// <param name="mapper"></param>
[Authorize]
public class DefinitionMessageService(
    ILogger<DefinitionMessageService> logger,
    ICommandDispatcher commandDispatcher,
    IQueryDispatcher queryDispatcher,
    IMapper mapper)
    : DefinitionBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task<GetDefinitionsResponse> GetDefinitions(GetDefinitionsRequest request,
        ServerCallContext context)
    {
        var definitions =
            await queryDispatcher.Dispatch<GetAllDefinitions, List<Core.Entities.AppDefinitions>>(
                new GetAllDefinitions());
        return new GetDefinitionsResponse
        {
            Definitions = { definitions.Select(mapper.Map<DefinitionMessage>).ToArray() }
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task<GetDefinitionResponse> GetDefinition(GetDefinitionRequest request,
        ServerCallContext context)
    {
        var definition = await queryDispatcher.Dispatch<GetByIdDefinition, Core.Entities.AppDefinitions>(
            new GetByIdDefinition
                { Id = request.Id != null ? new Guid(request.Id) : Guid.Empty, ThrowNotFoundIfNull = true });
        return new GetDefinitionResponse
        {
            Definition = mapper.Map<DefinitionMessage>(definition)
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task<AddDefinitionResponse> AddDefinition(AddDefinitionRequest request,
        ServerCallContext context)
    {
        var definition = mapper.Map<Core.Entities.AppDefinitions>(request.Definition);
        var result =
            await commandDispatcher.Dispatch<AddUpdateDefinitionCommand, Core.Entities.AppDefinitions>(
                new AddUpdateDefinitionCommand(definition));

        return new AddDefinitionResponse
        {
            Definition = mapper.Map<DefinitionMessage>(result)
        };
    }
}