using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Queries;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.QueryHandlers;

public class GetEventUserListQueryHandler : IRequestHandler<GetEventUserListQuery, EventUserListDto>
{
    private readonly IGenericRepository<EventUser> _eventUserRepository;
    private readonly IMapper _mapper;

    public GetEventUserListQueryHandler(IGenericRepository<EventUser> eventUserRepository, IMapper mapper)
    {
        _eventUserRepository = eventUserRepository;
        _mapper = mapper;
    }
    public async Task<EventUserListDto> Handle(GetEventUserListQuery request, CancellationToken cancellationToken)
    {
        var eventUsers = await _eventUserRepository.GetListAsync(
            orderBy:eu => eu.OrderByDescending(eu => eu.Id),
            index:request.PageRequest.Page,
            size:request.PageRequest.PageSize);
        var toReturn = _mapper.Map<EventUserListDto>(eventUsers);
        return toReturn;
    }
}