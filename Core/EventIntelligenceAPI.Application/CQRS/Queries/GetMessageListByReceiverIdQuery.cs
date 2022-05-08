using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Models;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class GetMessageListByReceiverIdQuery : IRequest<MessageListDto>
{
    public GetMessageListByReceiverIdQuery(int receiverId, PageRequest pageRequest)
    {
        ReceiverId = receiverId;
        PageRequest = pageRequest;
    }

    public PageRequest PageRequest { get; set; }
    public int ReceiverId { get; set; }
}