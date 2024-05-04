using AutoMapper;
using MeteorFlow.Auth.Jwt;
using MeteorFlow.Auth.Models;
using MeteorFlow.Auth.Services;
using MeteorFlow.Auth.Users.Queries;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Meteor.Auth.Api.Controllers;

public class AuthController(
    ILogger<AuthController> logger,
    ICommandDispatcher commandDispatcher,
    IQueryDispatcher queryDispatcher,
    IMapper mapper,
    AuthUserManager userManager): ControllerBase
{
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginInfo info)
    {
        var userByName = await userManager.FindByNameAsync(info.Name);
        if (userByName != null)
        {
            return Ok(await commandDispatcher.Dispatch<GenerateJwtTokenCommand, string>(new GenerateJwtTokenCommand
                { Username = info.Name }));
        }
        return Unauthorized();
            
    }
}