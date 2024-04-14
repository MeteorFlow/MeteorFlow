using System.ComponentModel.DataAnnotations;
using MeteorFlow.Auth.Core.Models;
using MeteorFlow.Auth.Core.Services.Identity;
using MeteorFlow.Auth.Core.Services.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeteorFlow.Auth.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IIdentityService identityService, IJwtService jwtService, ILogger<AuthController> logger)
    : ControllerBase
{
    private readonly ILogger<AuthController> _logger = logger;

    // [HttpPost("signup")]
    // public async ValueTask<IActionResult> Signup([FromBody] Accounts accounts)
    // {
    //     try
    //     {
    //
    //     }
    //     catch (ValidationException ex)
    //     {
    //         return BadRequest(ex.Message);
    //     }
    //     catch (Exception)
    //     {
    //         return StatusCode(StatusCodes.Status500InternalServerError);
    //     }
    // }

    [HttpPost("login")]
    public async ValueTask<IActionResult> Login([Required] LoginInfo info)
    {
        try
        {
            // await identityService.SignInAsync(info);
            var token = await jwtService.GenerateTokenFromUserName(info.Name);
            return Ok(token);
        }
        catch (ValidationException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [Authorize]
    [HttpPost("logout")]
    public async ValueTask<IActionResult> Logout()
    {
        try
        {
            // await identityService.SignOutAsync(User.Identity?.GetUserId());
            await identityService.ResetUserLockoutAsync(User.Identity?.GetUserId());
            return Ok();
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}