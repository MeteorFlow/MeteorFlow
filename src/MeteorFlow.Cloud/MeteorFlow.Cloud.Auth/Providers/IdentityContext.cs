using MeteorFlow.Cloud.Auth.Extensions;
using MeteorFlow.Core.Fx.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Cloud.Auth.Providers;

// public class IdentityContext : I, IIdentityContext
// {
//     private readonly IdentityManager _identityManager;
//
//     public IdentityContext(IdentityManager identityManager)
//     {
//         _identityManager = identityManager;
//     }
//
//     public async Task<IdentityBase> GetByIdAsync(string id)
//     {
//         return await _identityManager.FindByIdAsync(id);
//     }
//
//     public Task<IdentityBase> GetByUserName(string userName)
//     {
//         return _identityManager.FindByNameAsync(userName);
//     }
//
//     public Task<bool> CheckPassword(IdentityBase account, string password)
//     {
//         return _identityManager.CheckPasswordAsync(account, password);
//     }
//
//     public Task<bool> IsExistUserName(string userName)
//     {
//         return _identityManager.Users.AnyAsync(account => account.UserName == userName);
//     }
//
//     public Task<IdentityResult> CreateAccount(IdentityBase account)
//     {
//         return _identityManager.CreateAsync(account, account.Password);
//     }
//
//     public async Task UpdateAsync(IdentityBase account)
//     {
//         await _identityManager.UpdateAsync(account);
//     }
//
//     public async Task UpdateSecurityStampAsync(IdentityBase account)
//     {
//         await _identityManager.UpdateSecurityStampAsync(account);
//     }
//
//     public async Task<bool> IncrementAccessFailedCountAsync(IdentityBase user)
//     {
//         var result = await _identityManager.AccessFailedAsync(user);
//         return result.Succeeded;
//     }
//
//     public async Task<bool> IsUserLockedOutAsync(IdentityBase user)
//     {
//         var lockoutEndDate = await _identityManager.GetLockoutEndDateAsync(user);
//
//         return (lockoutEndDate.HasValue && lockoutEndDate.Value > DateTimeOffset.Now);
//     }
//
//     public async Task ResetUserLockoutAsync(IdentityBase user)
//     {
//         await _identityManager.SetLockoutEndDateAsync(user, null);
//         await _identityManager.ResetAccessFailedCountAsync(user);
//     }
// }