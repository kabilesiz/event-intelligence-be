using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Queries;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventIntelligenceAPI.Application.CQRS.QueryHandlers;

public class GetMessageListByReceiverIdQueryHandler : IRequestHandler<GetMessageListByReceiverIdQuery, MessageListDto>
{
    private readonly IGenericRepository<Message> _messageRepository;
    private readonly IMapper _mapper;

    public GetMessageListByReceiverIdQueryHandler(IGenericRepository<Message> messageRepository, IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
    }
    public async Task<MessageListDto> Handle(GetMessageListQuery request, CancellationToken cancellationToken)
    {
        var messages = await _messageRepository.GetListAsync(
            index:request.PageRequest.Page,
            size:request.PageRequest.PageSize);
        var toReturn = _mapper.Map<MessageListDto>(messages);
        return toReturn;
    }

    public async Task<MessageListDto> Handle(GetMessageListByReceiverIdQuery request, CancellationToken cancellationToken)
    {
        var messages = await _messageRepository.GetListAsync(
            predicate:x => x.ReceiverUserId == request.ReceiverId,
            include:x => x.Include(x => x.SenderUser),
            orderBy: x => x.OrderByDescending(x =>x.Id),
            index:request.PageRequest.Page,
            size:request.PageRequest.PageSize);
        var toReturn = _mapper.Map<MessageListDto>(messages);
        return toReturn;
    }
}