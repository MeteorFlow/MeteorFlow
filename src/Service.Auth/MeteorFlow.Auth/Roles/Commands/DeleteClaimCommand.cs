using MeteorFlow.Application.Commands;
using MeteorFlow.Auth.Entities;
using MeteorFlow.Auth.Repositories;

namespace MeteorFlow.Auth.Roles.Commands;

public class DeleteClaimCommand : ICommand<Role>
{
    public Role Role { get; set; }
    public RoleClaims Claim { get; set; }
}

public class DeleteClaimCommandHandler : ICommandHandler<DeleteClaimCommand, Role>
{
    private readonly IRoleRepository _roleRepository;

    public DeleteClaimCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Role> HandleAsync(DeleteClaimCommand command, CancellationToken cancellationToken = default)
    {
        command.Role.Claims.Remove(command.Claim);
        await _roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return command.Role;
    }
}
