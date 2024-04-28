using MeteorFlow.Auth.Core.Entities;
using MeteorFlow.Fx.Commands;

namespace MeteorFlow.Auth.Core.Commands;

public class AddClaimCommand: ICommand<Roles>
{
    public Roles Role { get; set; }
    public RoleClaims Claim { get; set; }
}

public class AddClaimCommandHandler : ICommandHandler<AddClaimCommand, Roles>
{
    private readonly IRoleRepository _roleRepository;

    public AddClaimCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Roles> HandleAsync(AddClaimCommand command, CancellationToken cancellationToken = default)
    {
        command.Role.Claims.Add(command.Claim);
        await _roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}