using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.CommandHandlers;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, CommentDto>
{
    private readonly IGenericRepository<Comment> _commentRepository;
    private readonly IMapper _mapper;

    public DeleteCommentCommandHandler(IGenericRepository<Comment> commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    public async Task<CommentDto> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetAsync(u => u.Id == request.Id);
        if (comment != null)
        {
            var deletedUser = await _commentRepository.DeleteAsync(comment);
            var result = _mapper.Map<CommentDto>(deletedUser);
            return result;
        }

        throw new Exception();
    }
}