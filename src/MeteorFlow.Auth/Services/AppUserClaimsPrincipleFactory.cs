using System.Security.Claims;
using MeteorFlow.Auth.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace MeteorFlow.Auth.Services;

public class AppUserClaimsPrincipleFactory(UserManager<User> userManager, IOptions<IdentityOptions> optionsAccessor)
    : UserClaimsPrincipalFactory<User>(userManager, optionsAccessor)
{
    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User identity)
    {
        var claimsIdentity = await base.GenerateClaimsAsync(identity);
        claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, identity.Id.ToString(), ClaimValueTypes.String));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Email,identity?.Email));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, identity.UserName));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.MobilePhone,identity.PhoneNumber));
        // claimsIdentity.AddClaim(new Claim(ClaimTypes.UserData, identity.Id.ToString(), ClaimValueTypes.String));

        // claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, identity.Type.ToString()));

        // claimsIdentity.AddClaim(new Claim(ClaimTypes.Role,RoleManager.GetRoleNameAsync(user.Role)));


        return claimsIdentity;
    }
}