using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Queries;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.QueryHandlers;

public class GetCommentsByEventIdQueryHandler : IRequestHandler<GetCommentsByEventIdQuery, CommentListDto>
{
    private readonly IGenericRepository<Comment> _commentRepository;
    private readonly IMapper _mapper;

    public GetCommentsByEventIdQueryHandler(IGenericRepository<Comment> commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    public async Task<CommentListDto> Handle(GetCommentsByEventIdQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetListAsync(
            predicate:x => x.EventId == request.EventId,
            orderBy: x => x.OrderByDescending(y => y.Id),
            index:request.PageRequest.Page,
            size:request.PageRequest.PageSize);
        var toReturn = _mapper.Map<CommentListDto>(comments);
        return toReturn;
    }
}