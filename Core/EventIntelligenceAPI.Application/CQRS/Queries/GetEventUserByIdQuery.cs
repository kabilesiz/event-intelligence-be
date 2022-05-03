using EventIntelligenceAPI.Application.Dtos;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class GetEventUserByIdQuery : IRequest<EventUserDto>
{
    public GetEventUserByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}