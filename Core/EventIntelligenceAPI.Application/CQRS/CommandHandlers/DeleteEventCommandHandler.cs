using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.CommandHandlers;

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, EventDto>
{
    private readonly IGenericRepository<Event> _eventRepository;
    private readonly IMapper _mapper;

    public DeleteEventCommandHandler(IGenericRepository<Event> eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<EventDto> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var eEvent = await _eventRepository.GetAsync(u => u.Id == request.Id);
        if (eEvent != null)
        {
            var deletedUser = await _eventRepository.DeleteAsync(eEvent);
            var result = _mapper.Map<EventDto>(deletedUser);
            return result;
        }

        throw new Exception();
    }
}