using EventIntelligenceAPI.Application.Dtos;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class GetEventByIdQuery : IRequest<EventDto>
{
    public GetEventByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}