using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Commands;

public class CreateCommentCommand : IRequest
{
    public int UserId { get; set; }
    public int EventId { get; set; }
    public string Body { get; set; }
}