using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Models;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class GetCommentListQuery : IRequest<CommentListDto>
{
    public PageRequest PageRequest { get; set; }

    public GetCommentListQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }
}