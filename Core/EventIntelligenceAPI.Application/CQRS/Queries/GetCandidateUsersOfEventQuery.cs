using EventIntelligenceAPI.Application.Dtos;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class GetCandidateUsersOfEventQuery : IRequest<List<AssignedUserDto>>
{
    public GetCandidateUsersOfEventQuery(int id)
        {
            EventId = id;
        }
    
        public int EventId { get; set; }
}