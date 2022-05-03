using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Commands;

public class UpdateCommentCommand : IRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int EventId { get; set; }
    public string Body { get; set; }
}