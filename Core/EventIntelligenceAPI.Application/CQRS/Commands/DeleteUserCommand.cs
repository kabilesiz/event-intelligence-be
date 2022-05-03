using EventIntelligenceAPI.Application.Dtos;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Commands;

public class DeleteUserCommand: IRequest<UserDto>
{
    public DeleteUserCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}