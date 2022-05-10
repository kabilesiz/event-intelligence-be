using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.CommandHandlers;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
{
    private readonly IGenericRepository<Role> _roleRepository;
    private readonly IMapper _mapper;

    public UpdateRoleCommandHandler(IGenericRepository<Role> roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetAsync(x => x.Id == request.Id);
        if (role != null)
        {
            role.Definition = request.Definition;
            role.UpdatedDate = DateTime.UtcNow;
            await _roleRepository.UpdateAsync(role);
            return Unit.Value;
        }

        throw new Exception();
    }
}
