using EventIntelligenceAPI.Application.Dtos;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class GetMessageByIdQuery : IRequest<MessageDto>
{
    public GetMessageByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}