using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Commands;

public class UpdateRoleCommand : IRequest
{
    public string Definition { get; set; }
    public int Id { get; set; }
}