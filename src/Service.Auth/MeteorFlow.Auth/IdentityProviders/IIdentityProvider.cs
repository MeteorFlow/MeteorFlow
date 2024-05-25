using System.Collections.Generic;
using System.Threading.Tasks;
using MeteorFlow.Auth.IdentityProviders;

namespace ClassifiedAds.Services.Identity.IdentityProviders;

public interface IIdentityProvider
{
    Task<IList<IUser>> GetUsersAsync();

    Task<IUser> GetUserById(string userId);

    Task<IUser> GetUserByUsernameAsync(string username);

    Task CreateUserAsync(IUser user);

    Task UpdateUserAsync(string userId, IUser user);

    Task DeleteUserAsync(string userId);
}
