using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Queries;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.QueryHandlers;

public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, EventListDto>
{
    private readonly IGenericRepository<Event> _eventRepository;
    private readonly IMapper _mapper;

    public GetEventListQueryHandler(IGenericRepository<Event> eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }
    public async Task<EventListDto> Handle(GetEventListQuery request, CancellationToken cancellationToken)
    {
        var events = await _eventRepository.GetListAsync(
            orderBy: p => p.OrderByDescending(p => p.Id),
            index:request.PageRequest.Page,
            size:request.PageRequest.PageSize);
        var toReturn = _mapper.Map<EventListDto>(events);
        return toReturn;
    }
}