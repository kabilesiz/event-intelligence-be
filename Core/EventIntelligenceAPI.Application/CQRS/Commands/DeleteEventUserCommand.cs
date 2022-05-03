using EventIntelligenceAPI.Application.Dtos;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Commands;

public class DeleteEventUserCommand: IRequest<EventUserDto>
{
    public DeleteEventUserCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}