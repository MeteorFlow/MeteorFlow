using AutoMapper;
using MeteorFlow.Core.VersionControls.Commands;
using MeteorFlow.Core.VersionControls.Queries;
using MeteorFlow.Domain.App;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Queries;
using MeteorFlow.Web.Authorizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeteorFlow.Web.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
public class VersionController(
    IQueryDispatcher queryDispatcher,
    ILogger<SettingController> logger,
    ICommandDispatcher commandDispatcher,
    IMapper mapper)
    : ControllerBase
{
    [Authorize(AuthorizationPolicyNames.GetSettingsPolicy)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppVersionControls>>> Get()
    {
        logger.LogInformation("Getting all settings");
        var settings = await queryDispatcher.Dispatch<GetAllVersionControls, List<Core.Entities.AppVersionControls>>(new GetAllVersionControls());
        return Ok(mapper.Map<List<AppVersionControls>>(settings));
    }
    
    [Authorize(AuthorizationPolicyNames.GetSettingPolicy)]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AppVersionControls>> Get(Guid id)
    {
        logger.LogInformation("Getting setting with id: {id}", id);
        var settings = await queryDispatcher.Dispatch<GetByIdVersionControl, Core.Entities.AppVersionControls>(new GetByIdVersionControl { Id = id, ThrowNotFoundIfNull = true });
        return Ok(mapper.Map<AppVersionControls>(settings));
    }
    
    [Authorize(AuthorizationPolicyNames.AddSettingPolicy)]
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<AppVersionControls>> Post([FromBody] AppVersionControls model)
    {
        logger.LogInformation("Adding setting with id: {id}", model.Id);
        var setting = await commandDispatcher.Dispatch<AddUpdateVersionControlCommand, Core.Entities.AppVersionControls>(new AddUpdateVersionControlCommand(mapper.Map<Core.Entities.AppVersionControls>(model)));
        return Created($"/api/setting/{model.Id}", mapper.Map<AppVersionControls>(setting));
    }
    
    [Authorize(AuthorizationPolicyNames.DeleteSettingPolicy)]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Deleting setting with id: {id}", id);
        var setting = await queryDispatcher.Dispatch<GetByIdVersionControl, Core.Entities.AppVersionControls>(new GetByIdVersionControl { Id = id, ThrowNotFoundIfNull = true });
        await commandDispatcher.Dispatch<DeleteVersionControlCommand, Core.Entities.AppVersionControls>(new DeleteVersionControlCommand (setting));
        return Ok();
    }
}