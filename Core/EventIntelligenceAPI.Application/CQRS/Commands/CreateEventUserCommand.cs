using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Commands;

public class CreateEventUserCommand : IRequest
{
    public int UserId { get; set; }
    public int EventId { get; set; }
}