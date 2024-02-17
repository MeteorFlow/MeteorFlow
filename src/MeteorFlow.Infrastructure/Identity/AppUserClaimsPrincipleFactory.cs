using System.Security.Claims;
using MeteorFlow.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace MeteorFlow.Infrastructure.Identity;

public class AppUserClaimsPrincipleFactory(UserManager<Account> userManager, IOptions<IdentityOptions> optionsAccessor)
    : UserClaimsPrincipalFactory<Account>(userManager, optionsAccessor)
{
    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Account account)
    {
        var claimsIdentity = await base.GenerateClaimsAsync(account);
        claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, account.Id.ToString(), ClaimValueTypes.String));
        //claimsIdentity.AddClaim(new Claim(ClaimTypes.Email,user?.Email));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, account.UserName));
        // claimsIdentity.AddClaim(new Claim(ClaimTypes.MobilePhone,user.PhoneNumber));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.UserData, account.ProfileId.ToString(), ClaimValueTypes.String));

        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, account.Type.ToString()));

        //claimsIdentity.AddClaim(new Claim(ClaimTypes.Role,RoleManager.GetRoleNameAsync(user.Roles)));


        return claimsIdentity;
    }
}