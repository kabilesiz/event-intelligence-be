using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.CommandHandlers;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, RoleDto>
{
    private readonly IGenericRepository<Role> _roleRepository;
    private readonly IMapper _mapper;

    public DeleteRoleCommandHandler(IGenericRepository<Role> roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }
    public async Task<RoleDto> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetAsync(u => u.Id == request.Id);
        if (role != null)
        {
            var deletedUser = await _roleRepository.DeleteAsync(role);
            var result = _mapper.Map<RoleDto>(deletedUser);
            return result;
        }

        throw new Exception();
    }
}