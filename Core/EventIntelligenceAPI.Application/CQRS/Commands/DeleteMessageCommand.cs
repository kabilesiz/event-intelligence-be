using EventIntelligenceAPI.Application.Dtos;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Commands;

public class DeleteMessageCommand : IRequest<MessageDto>
{
    public DeleteMessageCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
    
}