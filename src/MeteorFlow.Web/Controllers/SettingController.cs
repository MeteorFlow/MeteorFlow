using AutoMapper;
using MeteorFlow.Core.Settings.Commands;
using MeteorFlow.Core.Settings.Queries;
using MeteorFlow.Domain.App;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Queries;
using MeteorFlow.Web.Authorizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeteorFlow.Web.Controllers;

[Produces("application/json")]
[Route("api/core/[controller]")]
public class SettingController(
    IQueryDispatcher queryDispatcher,
    ILogger<SettingController> logger,
    ICommandDispatcher commandDispatcher,
    IMapper mapper)
    : ControllerBase
{
    [Authorize(AuthorizationPolicyNames.GetSettingsPolicy)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppSettings>>> Get()
    {
        logger.LogInformation("Getting all settings");
        var settings = await queryDispatcher.Dispatch<GetAllSettings, List<Core.Entities.AppSettings>>(new GetAllSettings());
        return Ok(mapper.Map<List<AppSettings>>(settings));
    }
    
    [Authorize(AuthorizationPolicyNames.GetSettingPolicy)]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AppSettings>> Get(Guid id)
    {
        logger.LogInformation("Getting setting with id: {id}", id);
        var settings = await queryDispatcher.Dispatch<GetByIdSetting, Core.Entities.AppSettings>(new GetByIdSetting { Id = id, ThrowNotFoundIfNull = true });
        return Ok(mapper.Map<AppSettings>(settings));
    }
    
    [Authorize(AuthorizationPolicyNames.AddSettingPolicy)]
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<AppSettings>> Post([FromBody] AppSettings model)
    {
        logger.LogInformation("Adding setting with id: {id}", model.Id);
        var setting =await commandDispatcher.Dispatch<AddUpdateSettingCommand, Core.Entities.AppSettings>(new AddUpdateSettingCommand(mapper.Map<Core.Entities.AppSettings>(model)));
        return Created($"/api/setting/{model.Id}", mapper.Map<AppSettings>(setting));
    }
    
    [Authorize(AuthorizationPolicyNames.DeleteSettingPolicy)]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Deleting setting with id: {id}", id);
        var setting = await queryDispatcher.Dispatch<GetByIdSetting, Core.Entities.AppSettings>(new GetByIdSetting { Id = id, ThrowNotFoundIfNull = true });
        await commandDispatcher.Dispatch<DeleteSettingCommand, Core.Entities.AppSettings>(new DeleteSettingCommand (setting));
        return Ok();
    }
}