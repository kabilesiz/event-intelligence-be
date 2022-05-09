using EventIntelligenceAPI.Application.Dtos;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class GetAssignedUsersOfEventQuery : IRequest<List<AssignedUserDto>>
{
    public GetAssignedUsersOfEventQuery(int id)
    {
        EventId = id;
    }

    public int EventId { get; set; }
}