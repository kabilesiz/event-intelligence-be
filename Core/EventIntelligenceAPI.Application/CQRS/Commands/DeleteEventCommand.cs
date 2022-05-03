using EventIntelligenceAPI.Application.Dtos;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Commands;

public class DeleteEventCommand : IRequest<EventDto>
{
    public DeleteEventCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}