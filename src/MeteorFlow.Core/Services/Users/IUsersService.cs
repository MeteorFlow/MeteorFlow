using MeteorFlow.Domain.Utils;

namespace MeteorFlow.Core.Services.Users;
using Domain;

public interface IUsersService
{
    ValueTask<ICollection<Profiles>> GetAllUsersAsync();
    ValueTask<ICollection<Accounts>> GetAllAccountsAsync();
    ValueTask<Profiles> GetById(int id);
    ValueTask<Profiles> GetById(BaseEntity<int> id);
    ValueTask UpdateAsync(ICollection<Profiles> users);
    ValueTask RemoveAsync(int id);
}