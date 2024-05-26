using AutoMapper;
using MeteorFlow.Application.Commands;
using MeteorFlow.Application.Handlers;
using MeteorFlow.Application.Queries;
using MeteorFlow.Auth.Authorization;
using MeteorFlow.Auth.Roles.Commands;
using MeteorFlow.Auth.Roles.Queries;
using MeteorFlow.Auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities = MeteorFlow.Auth.Entities;
using Domain = MeteorFlow.Auth.Models;

namespace Meteor.Auth.Api.Controllers;

[Authorize]
[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class RolesController(
    ILogger<RolesController> logger,
    AuthUserManager userManager,
    ICommandDispatcher commandDispatcher,
    IQueryDispatcher queryDispatcher,
    IMapper mapper)
    : ControllerBase
{


    [Authorize(AuthorizationPolicyNames.GetRolesPolicy)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Domain.Role>>> Get()
    {
        var roles = await queryDispatcher.Dispatch<GetRolesQuery, List<Entities.Role>>(new GetRolesQuery { AsNoTracking = true });
        var model = mapper.Map<List<Domain.Role>>(roles);
        return Ok(model);
    }

    [Authorize(AuthorizationPolicyNames.GetRolePolicy)]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Domain.Role>> Get(Guid id)
    {
        var role = await queryDispatcher.Dispatch<GetRoleQuery, Entities.Role>(new GetRoleQuery { Id = id, AsNoTracking = true });
        var model = mapper.Map<Domain.Role>(role);
        return Ok(model);
    }

    [Authorize(AuthorizationPolicyNames.AddRolePolicy)]
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Domain.Role>> Post([FromBody] Domain.Role model)
    {
        var role = new Entities.Role
        {
            Name = model.Name,
            NormalizedName = model.Name.ToUpper(),
        };

        var result = await commandDispatcher.Dispatch<AddUpdateRoleCommand, Entities.Role>(new AddUpdateRoleCommand { Role = role });

        return Created($"/api/roles/{result.Id}", mapper.Map<Entities.Role>(result));
    }

    [Authorize(AuthorizationPolicyNames.UpdateRolePolicy)]
    [HttpPut("{id}")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put([FromBody] Domain.Role model)
    {
        var role = await queryDispatcher.Dispatch<GetRoleQuery, Entities.Role>(new GetRoleQuery { Id = model.Id, AsNoTracking = true });

        role.Name = model.Name;
        role.NormalizedName = model.Name.ToUpper();

        var result = await commandDispatcher.Dispatch<AddUpdateRoleCommand, Entities.Role>(new AddUpdateRoleCommand { Role = role });
        
        return Ok(mapper.Map<Entities.Role>(result));
    }

    [Authorize(AuthorizationPolicyNames.DeleteRolePolicy)]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id)
    {
        var role = await queryDispatcher.Dispatch<GetRoleQuery, Entities.Role>(new GetRoleQuery { Id = id });
        await commandDispatcher.Dispatch<DeleteRoleCommand, Entities.Role>(new DeleteRoleCommand { Role = role });

        return Ok();
    }
    
    [HttpPost("{roleName}")]
    public async Task<ActionResult> AssignRoleAsync([FromBody] Domain.User user, [FromRoute] string roleName)
    {
        var result = await userManager.AddToRoleAsync(mapper.Map<Entities.User>(user), roleName);
        
        return Ok(result);
    }
}