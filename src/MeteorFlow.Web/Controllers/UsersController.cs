using System.ComponentModel.DataAnnotations;
using MeteorFlow.Core.Services.Users;
using MeteorFlow.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeteorFlow.Web.Controllers;
[ApiController]
[Authorize]
[Route("api/users")]
public class UsersController(ILogger<UsersController> logger, IUsersService usersService)
    : ControllerBase
{
    private readonly ILogger<UsersController> _logger = logger;

    [HttpGet]
    public async ValueTask<IActionResult> GetAllUsers()
    {
        try
        {
            var users = await usersService.GetAllUsersAsync();
            return Ok(users);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost("update")]
    public async ValueTask<IActionResult> UpdateUser(ICollection<Profiles> users)
    {
        try
        {
            await usersService.UpdateAsync(users);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("account")]
    public async ValueTask<IActionResult> GetAllAccounts()
    {
        try
        {
            var accounts = await usersService.GetAllAccountsAsync();
            return Ok(accounts);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }



    [HttpDelete("account")]
    public async ValueTask<IActionResult> DeleteAccountAsync([Required] int id)
    {
        try
        {
            await usersService.RemoveAsync(id);
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