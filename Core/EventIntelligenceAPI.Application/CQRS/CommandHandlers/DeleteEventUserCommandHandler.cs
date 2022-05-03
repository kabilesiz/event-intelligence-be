using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.CommandHandlers;

public class DeleteEventUserCommandHandler : IRequestHandler<DeleteEventUserCommand, EventUserDto>
{
    private readonly IGenericRepository<EventUser> _eventUserRepository;
    private readonly IMapper _mapper;

    public DeleteEventUserCommandHandler(IGenericRepository<EventUser> eventUserRepository, IMapper mapper)
    {
        _eventUserRepository = eventUserRepository;
        _mapper = mapper;
    }
    public async Task<EventUserDto> Handle(DeleteEventUserCommand request, CancellationToken cancellationToken)
    {
        var eventUser = await _eventUserRepository.GetAsync(u => u.Id == request.Id);
        if (eventUser != null)
        {
            var deletedEventUser = await _eventUserRepository.DeleteAsync(eventUser);
            var result = _mapper.Map<EventUserDto>(deletedEventUser);
            return result;
        }

        throw new Exception();
    }
}