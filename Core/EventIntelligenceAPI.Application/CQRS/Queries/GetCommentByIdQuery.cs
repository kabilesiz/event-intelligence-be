using EventIntelligenceAPI.Application.Dtos;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class GetCommentByIdQuery: IRequest<CommentDto>
{
    public GetCommentByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}