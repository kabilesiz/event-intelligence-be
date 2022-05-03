using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Queries;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.QueryHandlers;

public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, EventDto>
{
    private readonly IGenericRepository<Event> _eventRepository;
    private readonly IMapper _mapper;

    public GetEventByIdQueryHandler(IGenericRepository<Event> eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }
    public async Task<EventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var candidateEvent = await _eventRepository.GetAsync(u => u.Id == request.Id);
        var toReturn = _mapper.Map<EventDto>(candidateEvent);
        return toReturn;
    }
}