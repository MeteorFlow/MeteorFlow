using AutoMapper;
using MeteorFlow.Application.Commands;
using MeteorFlow.Application.Handlers;
using MeteorFlow.Auth.Jwt;
using MeteorFlow.Auth.Models;
using MeteorFlow.Auth.Services;
using MeteorFlow.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain = MeteorFlow.Auth.Models;
using Entities = MeteorFlow.Auth.Entities;

namespace Meteor.Auth.Api.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class AuthController(
    ILogger<AuthController> logger,
    ICommandDispatcher commandDispatcher,
    IMapper mapper,
    AuthUserManager userManager, ICurrentUser currentUser): ControllerBase
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
        var text = currentUser.IsAuthenticated ? "" : " not";
        logger.LogInformation($"User is{text} authenticated");

        return Ok(token);
    }
    
    [HttpPost]
    [AllowAnonymous]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterInfo info)
    {
        var user = new Domain.User
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