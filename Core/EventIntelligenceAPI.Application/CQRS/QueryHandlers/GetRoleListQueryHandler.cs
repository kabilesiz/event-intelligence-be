using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Queries;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.QueryHandlers;

public class GetRoleListQueryHandler : IRequestHandler<GetRoleListQuery, RoleListDto>
{
    private readonly IGenericRepository<Role> _roleRepository;
    private readonly IMapper _mapper;

    public GetRoleListQueryHandler(IGenericRepository<Role> roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }
    public async Task<RoleListDto> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
    {
        var roles = await _roleRepository.GetListAsync(
            index:request.PageRequest.Page,
            size:request.PageRequest.PageSize);
        var toReturn = _mapper.Map<RoleListDto>(roles);
        return toReturn;
    }
}