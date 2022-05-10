using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Queries;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.QueryHandlers;

public class GetCommentListQueryHandler : IRequestHandler<GetCommentListQuery, CommentListDto>
{
    private readonly IGenericRepository<Comment> _commentRepository;
    private readonly IMapper _mapper;

    public GetCommentListQueryHandler(IGenericRepository<Comment> commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    
    public async Task<CommentListDto> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetListAsync(
            orderBy:c => c.OrderByDescending(c => c.Id),
            index:request.PageRequest.Page,
            size:request.PageRequest.PageSize);
        var toReturn = _mapper.Map<CommentListDto>(comments);
        return toReturn;
    }
}