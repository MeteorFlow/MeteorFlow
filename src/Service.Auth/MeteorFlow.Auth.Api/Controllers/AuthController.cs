using System.Security.Claims;
using AutoMapper;
using MeteorFlow.Application.Handlers;
using MeteorFlow.Auth.Jwt;
using MeteorFlow.Auth.Models;
using MeteorFlow.Auth.Services;
using MeteorFlow.Auth.Users.Commands;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Entities = MeteorFlow.Auth.Entities;

namespace Meteor.Auth.Api.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class AuthController(
    ILogger<AuthController> logger,
    ICommandDispatcher commandDispatcher,
    IMapper mapper,
    AuthUserManager userManager): ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    [Route("")]
    public IActionResult RedirectRoute([FromQuery] string returnUrl = "/")
    {
        return Challenge(new AuthenticationProperties { RedirectUri = returnUrl }, "GitHub");   
    }
    [HttpPost]
    [AllowAnonymous]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginInfo info)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await userManager.FindByNameAsync(info.Name);
        if (user == null)
        {
            return Unauthorized();
        }

        var result = await userManager.CheckPasswordSignInAsync(user, info.Password, false);
        if (!result.Succeeded)
        {
            return Unauthorized();
        }

        var token = await commandDispatcher.Dispatch<GenerateJwtTokenCommand, string>(new GenerateJwtTokenCommand
            { User = user});

        return Ok(token);
    }
    
    [HttpGet("github-callback")]
    [AllowAnonymous]
    public async Task<IActionResult> GitHubCallback([FromQuery] string code, string state)
    {
        var result = await HttpContext.AuthenticateAsync("GitHub");

        if (!result.Succeeded)
        {
            return BadRequest(); // Handle error scenario
        }
        // Get the GitHub user details
        var userId = result.Principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId is not null)
        {
            var command = new SaveUserCommand
            {
                UserId = new Guid(userId),
                UserName = result.Principal.FindFirst(ClaimTypes.Name)?.Value,
                Email = result.Principal.FindFirst(ClaimTypes.Email)?.Value
            };
            
            await commandDispatcher.Dispatch<SaveUserCommand, Entities.User>(command);
        }
        
        return RedirectRoute(HttpContext.Request.GetEncodedUrl());
    }
    
    [HttpPost]
    [Authorize]
    [Route("refresh")]
    public async Task<IActionResult> Refresh()
    {
        var user = await userManager.GetUserAsync(User);
        var token = await commandDispatcher.Dispatch<GenerateJwtTokenCommand, string>(new GenerateJwtTokenCommand
        {
            User = user
        });
        return Ok(token);
    }
    
    [HttpPost]
    [Authorize]
    [Route("logout")]
    public IActionResult Logout()
    {
        return Ok();
    }
    
    [HttpPost]
    [AllowAnonymous]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterInfo info)
    {
        var user = new User
        {
            UserName = info.UserName,
            NormalizedUserName = info.UserName.ToUpper(),
            Email = info.Email,
            NormalizedEmail = info.Email.ToUpper(),
            EmailConfirmed = true,
            PhoneNumber = info.PhoneNumber,
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = true,
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            SecurityStamp = Guid.NewGuid().ToString(),
            LockoutEnabled = true,
            LockoutEnd = DateTime.UtcNow.AddDays(1),
            AccessFailedCount = 0
        };

        var entity = mapper.Map<Entities.User>(user);

        var result = await userManager.CreateAsync(entity, info.Password);
        if (result.Succeeded)
        {
            return Ok(new { Message = "User registered successfully." });
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return BadRequest(ModelState);
    }
    
    
    public class RegisterInfo
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}