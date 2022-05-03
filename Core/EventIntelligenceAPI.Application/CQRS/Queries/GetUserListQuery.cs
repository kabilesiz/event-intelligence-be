using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Models;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class GetUserListQuery : IRequest<UserListDto>
{
    public PageRequest PageRequest { get; set; }

    public GetUserListQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }
}