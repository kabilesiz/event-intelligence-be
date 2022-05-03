using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.CommandHandlers;

public class UpdateEventUserCommandHandler : IRequestHandler<UpdateEventUserCommand>
{
    private readonly IGenericRepository<EventUser> _eventUserRepository;
    private readonly IMapper _mapper;

    public UpdateEventUserCommandHandler(IGenericRepository<EventUser> eventUserRepository, IMapper mapper)
    {
        _eventUserRepository = eventUserRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateEventUserCommand request, CancellationToken cancellationToken)
    {
        var eventUser = await _eventUserRepository.GetAsync(x => x.Id == request.Id);
        if (eventUser != null)
        {
            eventUser.EventId = request.EventId;
            eventUser.UserId = request.UserId;
            await _eventUserRepository.UpdateAsync(eventUser);
            return Unit.Value;
        }
        throw new Exception();
    }
}