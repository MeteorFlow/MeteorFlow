using MeteorFlow.Application.Commands;
using MeteorFlow.Auth.Entities;
using MeteorFlow.Auth.Repositories;

namespace MeteorFlow.Auth.Roles.Commands;

public class AddUpdateRoleCommand : ICommand<Role>
{
    public Entities.Role Role { get; set; }
}

public class AddUpdateRoleCommandHandler : ICommandHandler<AddUpdateRoleCommand, Role>
{
    private readonly IRoleRepository _roleRepository;

    public AddUpdateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Role> HandleAsync(AddUpdateRoleCommand command, CancellationToken cancellationToken = default)
    {
        await _roleRepository.AddOrUpdateAsync(command.Role, cancellationToken);
        await _roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return command.Role;
    }
}
