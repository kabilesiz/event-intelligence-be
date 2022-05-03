using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Models;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class GetRoleListQuery  : IRequest<RoleListDto>
{
    public PageRequest PageRequest { get; set; }

    public GetRoleListQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }
}