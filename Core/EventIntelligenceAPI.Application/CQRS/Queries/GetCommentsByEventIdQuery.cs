using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Models;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class GetCommentsByEventIdQuery : IRequest<CommentListDto>
{

    public GetCommentsByEventIdQuery(int eventId, PageRequest pageRequest)
    {
        EventId = eventId;
        PageRequest = pageRequest;
    }

    public int EventId { get; set; }
    public PageRequest PageRequest { get; set; }
}