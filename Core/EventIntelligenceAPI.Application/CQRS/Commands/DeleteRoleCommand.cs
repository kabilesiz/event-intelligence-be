using EventIntelligenceAPI.Application.Dtos;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Commands;

public class DeleteRoleCommand : IRequest<RoleDto>
{
    public DeleteRoleCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}