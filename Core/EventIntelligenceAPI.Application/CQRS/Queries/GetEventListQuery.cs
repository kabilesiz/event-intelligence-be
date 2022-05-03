using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Models;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class GetEventListQuery : IRequest<EventListDto>
{
    public PageRequest PageRequest { get; set; }

    public GetEventListQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }
    
}