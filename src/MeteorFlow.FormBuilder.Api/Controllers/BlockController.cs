using AutoMapper;
using MeteorFlow.FormBuilder.Authorization;
using MeteorFlow.FormBuilder.Blocks.Commands;
using MeteorFlow.FormBuilder.Blocks.Queries;
using MeteorFlow.FormBuilder.Models;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeteorFlow.FormBuilder.Api.Controllers;

public class BlockController (
    IQueryDispatcher queryDispatcher,
    ICommandDispatcher commandDispatcher,
    ILogger<FormDefinitionController> logger,
    IMapper mapper)
    : ControllerBase
{
    [Authorize(AuthorizationPolicyNames.GetFormsPolicy)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FormBlocks>>> Get()
    {
        logger.LogInformation("Getting all definitions");
        var definitionsList = await queryDispatcher.Dispatch<GetAllBlocks, List<FormBuilder.Entities.FormBlocks>>(new GetAllBlocks());
        var models = mapper.Map<List<FormDefinitions>>(definitionsList);
        return Ok(models);
    }
    
    [Authorize(AuthorizationPolicyNames.GetFormPolicy)]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FormBlocks>> Get(Guid id)
    {
        logger.LogInformation("Getting setting with id: {id}", id);
        var settings = await queryDispatcher.Dispatch<GetByIdBlock, FormBuilder.Entities.FormBlocks>(new GetByIdBlock { Id = id, ThrowNotFoundIfNull = true });
        return Ok(mapper.Map<FormBlocks>(settings));
    }
    
    [Authorize(AuthorizationPolicyNames.AddFormPolicy)]
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<FormBlocks>> Post([FromBody] FormBlocks model)
    {
        logger.LogInformation("Adding setting with id: {id}", model.Id);
        var setting = await commandDispatcher.Dispatch<AddUpdateBlockCommand, FormBuilder.Entities.FormBlocks>(new AddUpdateBlockCommand(mapper.Map<FormBuilder.Entities.FormBlocks>(model)));
        return Created($"/api/setting/{model.Id}", mapper.Map<FormBlocks>(setting));
    }
    
    
    [Authorize(AuthorizationPolicyNames.DeleteFormPolicy)]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Deleting setting with id: {id}", id);
        var setting = await queryDispatcher.Dispatch<GetByIdBlock, FormBuilder.Entities.FormBlocks>(new GetByIdBlock { Id = id, ThrowNotFoundIfNull = true });
        await commandDispatcher.Dispatch<DeleteBlockCommand, FormBuilder.Entities.FormBlocks>(new DeleteBlockCommand (setting));
        return Ok();
    }
}