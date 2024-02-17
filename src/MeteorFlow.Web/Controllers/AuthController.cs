using System.ComponentModel.DataAnnotations;
using MeteorFlow.Core.Services.Stations;
using MeteorFlow.Core.Services.Users;
using MeteorFlow.Domain;
using MeteorFlow.Infrastructure.Extensions;
using MeteorFlow.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeteorFlow.Web.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IAccountService accountService, IJwtService jwtService, ILogger<AuthController> logger, IStationService stationService)
    : ControllerBase
{
    private readonly ILogger<AuthController> _logger = logger;

    [HttpPost("signup")]
    public async ValueTask<IActionResult> Signup([FromBody] Accounts accounts)
    {
        try
        {
            if (accounts is null)
            {
                throw new ValidationException("Account cannot be null");
            }

            if (accounts.Station is null)
            {
                throw new ValidationException("Account must be associated with a station");
            }

            var station = await stationService.GetStationByIdAsync(accounts.Station.Id);
            if (station is null)
            {
                throw new ValidationException("Station not found");
            }

            accounts.Station = station;
            
            var result = await accountService.AddAsync(accounts);
            return Ok(result);
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

    [HttpPost("login")]
    public async ValueTask<IActionResult> Login([Required] LoginInfo info)
    {
        try
        {
            await accountService.SignInAsync(info);
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
            await accountService.SignOutAsync(User.Identity?.GetUserId());
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