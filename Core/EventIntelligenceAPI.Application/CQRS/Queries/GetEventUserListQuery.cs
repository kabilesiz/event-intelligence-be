using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Models;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class GetEventUserListQuery : IRequest<EventUserListDto>
{
    public PageRequest PageRequest { get; set; }

    public GetEventUserListQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }
}