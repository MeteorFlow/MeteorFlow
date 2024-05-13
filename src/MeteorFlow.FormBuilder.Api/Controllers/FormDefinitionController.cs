// using AutoMapper;
// using MeteorFlow.Core.Definitions.Queries;
// using MeteorFlow.Core.Entities;
// using MeteorFlow.FormBuilder.Authorization;
// using MeteorFlow.FormBuilder.Models;
// using MeteorFlow.Fx.Queries;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace MeteorFlow.FormBuilder.Api.Controllers;
//
// [Route("api/[controller]")]
// public class FormDefinitionController(
//     IQueryDispatcher queryDispatcher,
//     ILogger<FormDefinitionController> logger,
//     IMapper mapper
// ) : ControllerBase
// {
//     [Authorize(AuthorizationPolicyNames.GetFormsPolicy)]
//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<FormDefinition>>> Get()
//     {
//         logger.LogInformation("Getting all definitions");
//         var definitionsList = await queryDispatcher.Dispatch<
//             GetAllDefinitions,
//             List<AppDefinitions>
//         >(new GetAllDefinitions());
//         var models = mapper.Map<List<FormDefinition>>(definitionsList);
//         return Ok(models);
//     }
//
//     [Authorize(AuthorizationPolicyNames.GetFormPolicy)]
//     [HttpGet("{id}")]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     [ProducesResponseType(StatusCodes.Status404NotFound)]
//     public async Task<ActionResult<FormDefinition>> Get(Guid id)
//     {
//         logger.LogInformation("Getting setting with id: {id}", id);
//         var settings = await queryDispatcher.Dispatch<GetByIdDefinition, AppDefinitions>(
//             new GetByIdDefinition { Id = id, ThrowNotFoundIfNull = true }
//         );
//         return Ok(mapper.Map<FormDefinition>(settings));
//     }
// }
