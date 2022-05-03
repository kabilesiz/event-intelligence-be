using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Models;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class GetMessageListQuery : IRequest<MessageListDto>
{
    public PageRequest PageRequest { get; set; }

    public GetMessageListQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }
}