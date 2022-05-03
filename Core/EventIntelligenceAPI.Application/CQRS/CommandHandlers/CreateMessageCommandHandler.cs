using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.CommandHandlers;

public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand>
{
    private readonly IGenericRepository<Message> _messageRepository;
    private readonly IMapper _mapper;

    public CreateMessageCommandHandler(IGenericRepository<Message> messageRepository, IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        var mappedMessage= _mapper.Map<Message>(request);
        await _messageRepository.AddAsync(mappedMessage);
        return Unit.Value;
    }
}