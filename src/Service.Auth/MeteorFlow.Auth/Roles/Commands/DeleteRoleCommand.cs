using MeteorFlow.Application.Commands;
using MeteorFlow.Auth.Entities;
using MeteorFlow.Auth.Repositories;

namespace MeteorFlow.Auth.Roles.Commands;

public class DeleteRoleCommand : ICommand<Role>
{
    public Role Role { get; set; }
}

public class DeleteRoleCommandHandler(IRoleRepository roleRepository) : ICommandHandler<DeleteRoleCommand, Role>
{
    public async Task<Role> HandleAsync(DeleteRoleCommand command, CancellationToken cancellationToken = default)
    {
        roleRepository.Delete(command.Role);
        await roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return command.Role;
    }
}
