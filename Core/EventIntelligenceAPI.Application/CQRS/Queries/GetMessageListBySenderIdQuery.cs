using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Models;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class GetMessageListBySenderIdQuery : IRequest<MessageListDto>
{
    public GetMessageListBySenderIdQuery(int senderId, PageRequest pageRequest)
    {
        SenderId = senderId;
        PageRequest = pageRequest;
    }

    public PageRequest PageRequest { get; set; }
    public int SenderId { get; set; }
}