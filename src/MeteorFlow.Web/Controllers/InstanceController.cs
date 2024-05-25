using AutoMapper;
using MeteorFlow.Core.Instances.Commands;
using MeteorFlow.Core.Instances.Queries;
using MeteorFlow.Domain.App;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Queries;
using MeteorFlow.Web.Authorizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeteorFlow.Web.Controllers;

[Produces("application/json")]
[Route("api/core/[controller]")]
public class InstanceController(
    IQueryDispatcher queryDispatcher,
    ILogger<SettingController> logger,
    ICommandDispatcher commandDispatcher,
    IMapper mapper)
    : ControllerBase
{
    [Authorize(AuthorizationPolicyNames.GetSettingsPolicy)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppInstances>>> Get()
    {
        logger.LogInformation("Getting all settings");
        var settings = await queryDispatcher.Dispatch<GetAllInstances, List<Core.Entities.AppInstances>>(new GetAllInstances());
        return Ok(mapper.Map<List<AppInstances>>(settings));
    }
    
    [Authorize(AuthorizationPolicyNames.GetSettingPolicy)]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AppInstances>> Get(Guid id)
    {
        logger.LogInformation("Getting setting with id: {id}", id);
        var settings = await queryDispatcher.Dispatch<GetByIdInstance, Core.Entities.AppInstances>(new GetByIdInstance { Id = id, ThrowNotFoundIfNull = true });
        return Ok(mapper.Map<AppInstances>(settings));
    }
    
    [Authorize(AuthorizationPolicyNames.AddSettingPolicy)]
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<AppInstances>> Post([FromBody] AppInstances model)
    {
        logger.LogInformation("Adding setting with id: {id}", model.Id);
        var setting = await commandDispatcher.Dispatch<AddUpdateInstanceCommand, Core.Entities.AppInstances>(new AddUpdateInstanceCommand(mapper.Map<Core.Entities.AppInstances>(model)));
        return Created($"/api/setting/{model.Id}", mapper.Map<AppInstances>(setting));
    }
    
    [Authorize(AuthorizationPolicyNames.DeleteSettingPolicy)]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Deleting setting with id: {id}", id);
        var setting = await queryDispatcher.Dispatch<GetByIdInstance, Core.Entities.AppInstances>(new GetByIdInstance { Id = id, ThrowNotFoundIfNull = true });
        await commandDispatcher.Dispatch<DeleteInstanceCommand, Core.Entities.AppInstances>(new DeleteInstanceCommand (setting));
        return Ok();
    }
}