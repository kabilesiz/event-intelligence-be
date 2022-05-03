using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.CommandHandlers;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand>
{
    private readonly IGenericRepository<Event> _eventRepository;
    private readonly IMapper _mapper;

    public CreateEventCommandHandler(IGenericRepository<Event> eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var eEvent = _mapper.Map<Event>(request);
        await _eventRepository.AddAsync(eEvent);
        return Unit.Value;
    }
}