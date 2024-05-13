using AutoMapper;
using MeteorFlow.Auth.Jwt;
using MeteorFlow.Auth.Models;
using MeteorFlow.Auth.Services;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meteor.Auth.Api.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class AuthController(
    ILogger<AuthController> logger,
    ICommandDispatcher commandDispatcher,
    IQueryDispatcher queryDispatcher,
    IMapper mapper,
    AuthUserManager userManager): ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    [Route("")]
    public IActionResult Login([FromQuery] string returnUrl)
    {
        if (User.Identity is not null && User.Identity.IsAuthenticated)
        {
            
            return Redirect(returnUrl);

        }

        var response = HttpContext.Response;
        var request = HttpContext.Request;
        return Redirect($"{request.Scheme}://localhost:3000");
            
    }
    [HttpPost]
    [AllowAnonymous]
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