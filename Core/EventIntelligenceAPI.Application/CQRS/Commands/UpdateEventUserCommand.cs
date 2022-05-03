using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Commands;

public class UpdateEventUserCommand : IRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int EventId { get; set; }
}