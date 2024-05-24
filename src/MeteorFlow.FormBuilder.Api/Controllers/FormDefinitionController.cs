using AutoMapper;
using MeteorFlow.Core.Grpc;
using MeteorFlow.FormBuilder.Authorization;
using MeteorFlow.FormBuilder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeteorFlow.FormBuilder.Api.Controllers;

[Route("api/[controller]")]
public class FormDefinitionController(
    ILogger<FormDefinitionController> logger,
    Definition.DefinitionClient client,
    IMapper mapper)
    : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DefinitionMessage>>> Get()
    {
        logger.LogInformation("Getting all definitions");
        var response = await client.GetDefinitionsAsync(new GetDefinitionsRequest());
        return Ok(response.Definitions.ToList());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DefinitionMessage>> Get(Guid id)
    {
        logger.LogInformation("Getting setting with id: {id}", id);
        var response = await client.GetDefinitionAsync(new GetDefinitionRequest());
        return Ok(response.Definition);
    }
}