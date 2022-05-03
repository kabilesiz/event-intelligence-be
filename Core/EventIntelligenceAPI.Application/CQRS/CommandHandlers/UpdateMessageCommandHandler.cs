using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.CommandHandlers;

public class UpdateMessageCommandHandler: IRequestHandler<UpdateMessageCommand>
{
    private readonly IGenericRepository<Message> _messageRepository;
    private readonly IMapper _mapper;

    public UpdateMessageCommandHandler(IGenericRepository<Message> messageRepository, IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
    {
        var message = await _messageRepository.GetAsync(x => x.Id == request.Id);
        if (message != null)
        {
            message.Body = request.Body;
            message.isDeleted = request.isDeleted;
            message.Title = request.Title;
            message.ReceiverUserId = request.ReceiverUserId;
            message.SenderUserId = request.SenderUserId;
            await _messageRepository.UpdateAsync(message);
            return Unit.Value;
        }

        throw new Exception();
    }
}