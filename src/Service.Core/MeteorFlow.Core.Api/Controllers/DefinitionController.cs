using AutoMapper;
using MeteorFlow.Application.Handlers;
using MeteorFlow.Core.Api.Authorizations;
using MeteorFlow.Core.Definitions.Commands;
using MeteorFlow.Core.Definitions.Queries;
using MeteorFlow.Domain.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeteorFlow.Core.Api.Controllers;

[Produces("application/json")]
[Route("api/core/[controller]")]
public class DefinitionController(
    IQueryDispatcher queryDispatcher,
    ILogger<SettingController> logger,
    ICommandDispatcher commandDispatcher,
    IMapper mapper)
    : ControllerBase
{
    [Authorize(AuthorizationPolicyNames.GetSettingsPolicy)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppDefinitions>>> Get()
    {
        logger.LogInformation("Getting all settings");
        var settings = await queryDispatcher.Dispatch<GetAllDefinitions, List<Core.Entities.AppDefinitions>>(new GetAllDefinitions());
        return Ok(mapper.Map<List<AppDefinitions>>(settings));
    }
    
    [Authorize(AuthorizationPolicyNames.GetSettingPolicy)]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AppDefinitions>> Get(Guid id)
    {
        logger.LogInformation("Getting setting with id: {id}", id);
        var settings = await queryDispatcher.Dispatch<GetByIdDefinition, Core.Entities.AppDefinitions>(new GetByIdDefinition { Id = id, ThrowNotFoundIfNull = true });
        return Ok(mapper.Map<AppDefinitions>(settings));
    }
    
    [Authorize(AuthorizationPolicyNames.AddSettingPolicy)]
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<AppDefinitions>> Post([FromBody] AppDefinitions model)
    {
        logger.LogInformation("Adding setting with id: {id}", model.Id);
        var setting = await commandDispatcher.Dispatch<AddUpdateDefinitionCommand, Core.Entities.AppDefinitions>(new AddUpdateDefinitionCommand(mapper.Map<Core.Entities.AppDefinitions>(model)));
        return Created($"/api/setting/{model.Id}", mapper.Map<AppDefinitions>(setting));
    }
    
    [Authorize(AuthorizationPolicyNames.DeleteSettingPolicy)]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Deleting setting with id: {id}", id);
        var setting = await queryDispatcher.Dispatch<GetByIdDefinition, Core.Entities.AppDefinitions>(new GetByIdDefinition { Id = id, ThrowNotFoundIfNull = true });
        await commandDispatcher.Dispatch<DeleteDefinitionCommand, Core.Entities.AppDefinitions>(new DeleteDefinitionCommand (setting));
        return Ok();
    }
}