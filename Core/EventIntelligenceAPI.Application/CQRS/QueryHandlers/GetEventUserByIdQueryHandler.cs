using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Queries;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.QueryHandlers;

public class GetEventUserByIdQueryHandler : IRequestHandler<GetEventUserByIdQuery, EventUserDto>
{
    private readonly IGenericRepository<EventUser> _eventUserRepository;
    private readonly IMapper _mapper;

    public GetEventUserByIdQueryHandler(IGenericRepository<EventUser> eventUserRepository, IMapper mapper)
    {
        _eventUserRepository = eventUserRepository;
        _mapper = mapper;
    }
    public async Task<EventUserDto> Handle(GetEventUserByIdQuery request, CancellationToken cancellationToken)
    {
        var candidateEvent = await _eventUserRepository.GetAsync(u => u.Id == request.Id);
        var toReturn = _mapper.Map<EventUserDto>(candidateEvent);
        return toReturn;
    }
}