using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.CommandHandlers;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
{
    private readonly IGenericRepository<Comment> _commentRepository;
    private readonly IMapper _mapper;

    public UpdateCommentCommandHandler(IGenericRepository<Comment> commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetAsync(x => x.Id == request.Id);
        if (comment != null)
        {
            comment.Body = request.Body;
            comment.EventId = request.EventId;
            comment.UserId = request.UserId;
            comment.UpdatedDate = DateTime.UtcNow;
            await _commentRepository.UpdateAsync(comment);
            return Unit.Value;
        }

        throw new Exception();
    }
}