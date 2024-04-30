using System.ComponentModel.DataAnnotations;
using MeteorFlow.Auth.Entities;
using MeteorFlow.Auth.Providers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Auth.Services.Identity;

public class IdentityService(IdentityManager identityManager) : IIdentityService
{
    public async Task<User> GetByIdAsync(string id)
     {
         var result = await identityManager.FindByIdAsync(id);
         if (result is null)
         {
             throw new ValidationException($"Invalid: {id} is not existed.");
         }

         return result;
     }

     public async Task<User> GetByUserName(string userName)
     {
         var result = await identityManager.FindByNameAsync(userName);
         if (result is null)
         {
             throw new ValidationException($"Invalid: {userName} is not existed.");
         }
         return result;
     }

     public Task<bool> CheckPassword(User account, string password)
     {
         return identityManager.CheckPasswordAsync(account, password);
     }

     public Task<bool> IsExistUserName(string userName)
     {
         return identityManager.Users.AnyAsync(account => account.UserName == userName);
     }

     public Task<IdentityResult> CreateAccount(User account)
     {
         if (account.PasswordHash is null)
         {
             throw new ValidationException($"Invalid: {nameof(account.PasswordHash)} should not be empty."); 
         } 
         return identityManager.CreateAsync(account, account.PasswordHash);
     }

     public async Task UpdateAsync(User account)
     {
         await identityManager.UpdateAsync(account);
     }

     public async Task UpdateSecurityStampAsync(User account)
     {
         await identityManager.UpdateSecurityStampAsync(account);
     }

     public async Task<bool> IncrementAccessFailedCountAsync(User user)
     {
         var result = await identityManager.AccessFailedAsync(user);
         return result.Succeeded;
     }

     public async Task<bool> IsUserLockedOutAsync(User user)
     {
         var lockoutEndDate = await identityManager.GetLockoutEndDateAsync(user);

         return (lockoutEndDate.HasValue && lockoutEndDate.Value > DateTimeOffset.Now);
     }

     public async Task ResetUserLockoutAsync(User user)
     {
         await identityManager.SetLockoutEndDateAsync(user, null);
         await identityManager.ResetAccessFailedCountAsync(user);
     }
}