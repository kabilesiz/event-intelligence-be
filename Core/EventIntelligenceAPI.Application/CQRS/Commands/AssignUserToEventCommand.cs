using EventIntelligenceAPI.Application.Dtos;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Commands;

public class AssignUserToEventCommand : IRequest
{
    public List<AssignedUserDto> AssignedUserList { get; set; }

    public AssignUserToEventCommand(List<AssignedUserDto> assignedUserList)
    {
        AssignedUserList = assignedUserList;
    }
}