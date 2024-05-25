using AutoMapper;
using MeteorFlow.Application.Handlers;
using MeteorFlow.Application.Queries;
using MeteorFlow.FormBuilder.Authorization;
using MeteorFlow.FormBuilder.Elements.Queries;
using MeteorFlow.FormBuilder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeteorFlow.FormBuilder.Api.Controllers;

[Route("api/[controller]")]
public class ElementController(
    IQueryDispatcher queryDispatcher,
    ILogger<ElementController> logger,
    IMapper mapper
) : ControllerBase
{
    [Authorize(AuthorizationPolicyNames.GetFormsPolicy)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FormElement>>> Get()
    {
        logger.LogInformation("Getting all elements");
        var results = await queryDispatcher.Dispatch<
            GetAllElements,
            List<Entities.FormElements>
        >(new GetAllElements());
        var models = mapper.Map<List<FormElement>>(results);
        return Ok(models);
    }
}