using System.Security.Claims;
using Microsoft.AspNetCore.Http;


namespace MeteorFlow.Infrastructure.Identity;

public class CurrentWebUser(IHttpContextAccessor context) : ICurrentUser
{
    public bool IsAuthenticated => context.HttpContext != null && context.HttpContext.User.Identity.IsAuthenticated;

    public Guid UserId
    {
        get
        {
            var userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                         ?? context.HttpContext.User.FindFirst("sub")?.Value;

            return Guid.Parse(userId ?? string.Empty);
        }
    }
}