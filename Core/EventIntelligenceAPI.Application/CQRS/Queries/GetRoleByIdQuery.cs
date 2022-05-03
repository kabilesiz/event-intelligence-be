using EventIntelligenceAPI.Application.Dtos;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class GetRoleByIdQuery : IRequest<RoleDto>
{
    public GetRoleByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}