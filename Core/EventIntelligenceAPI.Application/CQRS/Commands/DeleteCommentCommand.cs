using EventIntelligenceAPI.Application.Dtos;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Commands;

public class DeleteCommentCommand : IRequest<CommentDto>
{
    public DeleteCommentCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}