using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeteorFlow.Auth.Entities;

namespace MeteorFlow.Auth.Repositories
{
    public interface IUserRoleRepository : IAuthRepository<UserRole>
    {
        Task AddUserRoleAsync(Guid userId, Guid roleId);
        Task RemoveUserRoleAsync(Guid userId, Guid roleId);
        Task<IList<Role>> GetRolesByUserIdAsync(Guid userId);
        Task<bool> UserHasRoleAsync(Guid userId, Guid roleId);
        Task<IList<Guid>> GetUserIdsByRoleIdAsync(Guid roleId);
    }
}