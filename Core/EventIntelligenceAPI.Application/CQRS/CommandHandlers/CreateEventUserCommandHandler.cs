using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.CommandHandlers;

public class CreateEventUserCommandHandler : IRequestHandler<CreateEventUserCommand>
{
    private readonly IGenericRepository<EventUser> _eventUserRepository;
    private readonly IMapper _mapper;

    public CreateEventUserCommandHandler(IGenericRepository<EventUser> eventUserRepository, IMapper mapper)
    {
        _eventUserRepository = eventUserRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateEventUserCommand request, CancellationToken cancellationToken)
    {
        var eventUser = _mapper.Map<EventUser>(request);
        await _eventUserRepository.AddAsync(eventUser);
        return Unit.Value;
    }
}