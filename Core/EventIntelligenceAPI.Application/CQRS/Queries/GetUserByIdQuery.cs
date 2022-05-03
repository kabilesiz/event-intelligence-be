using EventIntelligenceAPI.Application.Dtos;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public int Id { get; set; }

    public GetUserByIdQuery(int id)
    {
        Id = id;
    }
}