using MeteorFlow.Auth.Models;
using MeteorFlow.Auth.Entities;
using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Auth.Services.Identity;

public interface IIdentityService
{
    // ValueTask SignInAsync(LoginInfo loginInfo);
    // ValueTask SignOutAsync(string id);
    Task<User> GetByIdAsync(string id);
    Task<User> GetByUserName(string userName);
    Task<bool> CheckPassword(User identity, string password);
    Task<bool> IsExistUserName(string userName);
    Task<IdentityResult> CreateAccount(User identity);
    Task UpdateAsync(User identity);
    Task UpdateSecurityStampAsync(User identity);
    Task<bool> IncrementAccessFailedCountAsync(User identity);
    Task<bool> IsUserLockedOutAsync(User identity);
    Task ResetUserLockoutAsync(User identity);
}