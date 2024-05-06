using System.Web;
using AutoMapper;
using MeteorFlow.Auth.Authorization;
using MeteorFlow.Auth.Services;
using MeteorFlow.Auth.Users.Commands;
using MeteorFlow.Auth.Users.Queries;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain = MeteorFlow.Auth.Models;
using Entities = MeteorFlow.Auth.Entities;

namespace Meteor.Auth.Api.Controllers;

[Authorize]
[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class UsersController(
    AuthUserManager userManager,
    IConfiguration configuration,
    ICommandDispatcher commandDispatcher,
    IQueryDispatcher queryDispatcher,
    ILogger<UsersController> logger,
    IMapper mapper)
    : ControllerBase
{


    [Authorize(AuthorizationPolicyNames.GetUsersPolicy)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Domain.User>>> Get()
    {
        var users = await queryDispatcher.Dispatch<GetUsersQuery, List<Entities.User>>(new GetUsersQuery());
        var model = mapper.Map<List<Domain.User>>(users);
        return Ok(model);
    }

    [Authorize(AuthorizationPolicyNames.GetUserPolicy)]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Domain.User>> Get(Guid id)
    {
        var user = await queryDispatcher.Dispatch<GetUserQuery, Entities.User>(new GetUserQuery { Id = id, AsNoTracking = true });
        var model = mapper.Map<Domain.User>(user);
        return Ok(model);
    }

    // [Authorize(AuthorizationPolicyNames.AddUserPolicy)]
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Domain.User>> Post([FromBody] Domain.User model)
    {
        var result = await userManager.CreateAsync(mapper.Map<Entities.User>(model));

        return Created($"/api/users/{model.Id}", mapper.Map<Domain.User>(result));
    }

    [Authorize(AuthorizationPolicyNames.UpdateUserPolicy)]
    [HttpPut("{id}")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put([FromBody] Domain.User model)
    {
        var user = await queryDispatcher.Dispatch<GetUserQuery, Entities.User>(new GetUserQuery { Id = model.Id });

        await userManager.UpdateAsync(mapper.Map<Entities.User>(user));

        return Ok(model);
    }

    [Authorize(AuthorizationPolicyNames.SetPasswordPolicy)]
    [HttpPut("{id}/password")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> SetPassword(Guid id, [FromBody] Domain.PasswordSetter model)
    {
        var user = await queryDispatcher.Dispatch<GetUserQuery, Entities.User>(new GetUserQuery { Id = id });

        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        var rs = await userManager.ResetPasswordAsync(user, token, model.Password);

        if (rs.Succeeded)
        {
            return Ok();
        }

        return BadRequest(rs.Errors);
    }

    [Authorize(AuthorizationPolicyNames.DeleteUserPolicy)]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id)
    {
        var user = await queryDispatcher.Dispatch<GetUserQuery, Entities.User>(new GetUserQuery { Id = id });
        await commandDispatcher.Dispatch<DeleteUserCommand, Entities.User>(new DeleteUserCommand { User = user });

        return Ok();
    }

    [Authorize(AuthorizationPolicyNames.SendResetPasswordEmailPolicy)]
    [HttpPost("{id}/passwordresetemail")]
    public async Task<ActionResult> SendResetPasswordEmail(Guid id)
    {
        Entities.User user = await queryDispatcher.Dispatch<GetUserQuery, Entities.User>(new GetUserQuery { Id = id });

        if (user != null)
        {
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var resetUrl = $"{configuration["IdentityServerAuthentication:Authority"]}/Account/ResetPassword?token={HttpUtility.UrlEncode(token)}&email={user.Email}";

            // await _dispatcher.DispatchAsync(new AddEmailMessageCommand
            // {
            //     EmailMessage = new EmailMessageDTO
            //     {
            //         From = "phong@gmail.com",
            //         Tos = user.Email,
            //         Subject = "Forgot Password",
            //         Body = string.Format("Reset Url: {0}", resetUrl),
            //     },
            // });
        }
        else
        {
            // email user and inform them that they do not have an account
        }

        return Ok();
    }

    [Authorize(AuthorizationPolicyNames.SendConfirmationEmailAddressEmailPolicy)]
    [HttpPost("{id}/emailaddressconfirmation")]
    public async Task<ActionResult> SendConfirmationEmailAddressEmail(Guid id)
    {
        Entities.User user = await queryDispatcher.Dispatch<GetUserQuery, Entities.User>(new GetUserQuery { Id = id });

        if (user != null)
        {
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

            var confirmationEmail = $"{configuration["IdentityServerAuthentication:Authority"]}/Account/ConfirmEmailAddress?token={HttpUtility.UrlEncode(token)}&email={user.Email}";

            // await _dispatcher.DispatchAsync(new AddEmailMessageCommand
            // {
            //     EmailMessage = new EmailMessageDTO
            //     {
            //         From = "phong@gmail.com",
            //         Tos = user.Email,
            //         Subject = "Confirmation Email",
            //         Body = string.Format("Confirmation Email: {0}", confirmationEmail),
            //     },
            // });
        }
        else
        {
            // email user and inform them that they do not have an account
        }

        return Ok();
    }
}