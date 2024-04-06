using MeteorFlow.Cloud.Auth.Models;
using MeteorFlow.Core.Fx.Identities;
using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Cloud.Auth.Services.Identity;

public interface IIdentityService
{
    // ValueTask SignInAsync(LoginInfo loginInfo);
    // ValueTask SignOutAsync(string id);
    Task<IdentityBase> GetByIdAsync(string id);
    Task<IdentityBase> GetByUserName(string userName);
    Task<bool> CheckPassword(IdentityBase identity, string password);
    Task<bool> IsExistUserName(string userName);
    Task<IdentityResult> CreateAccount(IdentityBase identity);
    Task UpdateAsync(IdentityBase identity);
    Task UpdateSecurityStampAsync(IdentityBase identity);
    Task<bool> IncrementAccessFailedCountAsync(IdentityBase identity);
    Task<bool> IsUserLockedOutAsync(IdentityBase identity);
    Task ResetUserLockoutAsync(IdentityBase identity);
}