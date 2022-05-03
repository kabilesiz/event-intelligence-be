using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Commands;

public class CreateRoleCommand : IRequest
{
    public string Definition { get; set; }
}