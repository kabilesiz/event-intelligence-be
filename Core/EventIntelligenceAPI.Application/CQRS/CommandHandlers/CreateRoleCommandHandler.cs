using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.CommandHandlers;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand>
{
    private readonly IGenericRepository<Role> _roleRepository;
    private readonly IMapper _mapper;

    public CreateRoleCommandHandler(IGenericRepository<Role> roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = _mapper.Map<Role>(request);
        role.CreatedDate = DateTime.UtcNow;
        role.UpdatedDate = DateTime.UtcNow;
        await _roleRepository.AddAsync(role);
        return Unit.Value;
    }
}