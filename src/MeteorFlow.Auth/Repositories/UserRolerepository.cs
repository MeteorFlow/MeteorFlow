using MeteorFlow.Auth.Entities;
using MeteorFlow.Fx.DateTimes;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Auth.Repositories
{
    public class UserRoleRepository : Repository<UserRole, Guid>, IUserRoleRepository
    {

        public UserRoleRepository(AuthDbContext dbContext, IDateTimeProvider dateTimeProvider) : base(dbContext,
            dateTimeProvider)
        {
        }
        
        public async Task AddUserRoleAsync(Guid userId, Guid roleId)
        {
            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = roleId
            };

            await DbSet.AddAsync(userRole);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveUserRoleAsync(Guid userId, Guid roleId)
        {
            var userRole = await DbSet
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

            if (userRole != null)
            {
                DbSet.Remove(userRole);
                await UnitOfWork.SaveChangesAsync();
            }
        }


        public async Task<IList<Role>> GetRolesByUserIdAsync(Guid userId)
        {
            var roles = await DbSet
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.Role)
                .ToListAsync();

            return roles;
        }

        public async Task<bool> UserHasRoleAsync(Guid userId, Guid roleId)
        {
            return await DbSet
                .AnyAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
        }

        public async Task<IList<Guid>> GetUserIdsByRoleIdAsync(Guid roleId)
        {
            var userIds = await DbSet
                .Where(ur => ur.RoleId == roleId)
                .Select(ur => ur.UserId)
                .ToListAsync();

            return userIds;
        }
    }
}