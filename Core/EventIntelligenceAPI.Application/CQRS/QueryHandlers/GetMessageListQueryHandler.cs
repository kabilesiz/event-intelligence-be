using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Queries;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.QueryHandlers;

public class GetMessageListQueryHandler : IRequestHandler<GetMessageListQuery, MessageListDto>
{
    private readonly IGenericRepository<Message> _messageRepository;
    private readonly IMapper _mapper;

    public GetMessageListQueryHandler(IGenericRepository<Message> messageRepository, IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
    }
    public async Task<MessageListDto> Handle(GetMessageListQuery request, CancellationToken cancellationToken)
    {
        var messages = await _messageRepository.GetListAsync(
            orderBy:m => m.OrderByDescending(m => m.Id),
            index:request.PageRequest.Page,
            size:request.PageRequest.PageSize);
        var toReturn = _mapper.Map<MessageListDto>(messages);
        return toReturn;
    }
}