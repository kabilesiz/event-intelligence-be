using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Commands;

public class CreateMessageCommand : IRequest
{
    public int SenderUserId { get; set; }
    public int ReceiverUserId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public bool isDeleted { get; set; }
}